﻿namespace PWSH.Kasplex.Base;

public sealed class KasplexJob<TResponse> : Job
{
    private readonly object _lock = new();
    private readonly CancellationTokenSource _internalCancellation = new();
    private readonly Func<CancellationToken, Task<Either<ErrorRecord, TResponse>>> _processTask;

    private bool _hasMoreData;
    private string _statusMessage;

/* -----------------------------------------------------------------
CONSTRUCTORS                                                       |
----------------------------------------------------------------- */

    public KasplexJob(Func<CancellationToken, Task<Either<ErrorRecord, TResponse>>> process_task, string command_name) : base(command_name)
    {
        lock (this._lock)
        {
            this._processTask = process_task;

            this._hasMoreData = true;
            this._statusMessage = "Job is initialized.";
            SetJobState(JobState.NotStarted);
        }
    }

/* -----------------------------------------------------------------
PARAMETERS                                                         |
----------------------------------------------------------------- */

    public override string Location => "LocalMachine";

    public override bool HasMoreData
    {
        get { lock (this._lock) { return this._hasMoreData; } }
    }

    public override string StatusMessage
    {
        get { lock (this._lock) { return this._statusMessage; } }
    }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

    public override void StopJob()
    {
        if (JobStateInfo.State is JobState.Running or JobState.NotStarted)
        {
            this._internalCancellation.Cancel();
            this._hasMoreData = false;
            this._statusMessage = "Job stopped.";
            SetJobState(JobState.Stopped);
        }
    }

    public async Task ProcessJob(CancellationToken cancellation_token)
    {
        try
        {
            lock (this._lock)
            {
                if (this._internalCancellation.Token.IsCancellationRequested || cancellation_token.IsCancellationRequested)
                {
                    this._hasMoreData = false;
                    this._statusMessage = "Job was canceled before it started.";
                    Output.Add(PSObject.AsPSObject("Job was canceled before execution."));
                    Output.Complete();
                    SetJobState(JobState.Stopped);
                    return;
                }

                this._statusMessage = "Job is running.";
                SetJobState(JobState.Running);
            }

            using var linkedCancellations = CancellationTokenSource.CreateLinkedTokenSource(this._internalCancellation.Token, cancellation_token);
            var result = await this._processTask(linkedCancellations.Token);

            lock (this._lock)
            {
                this._hasMoreData = false;

                result.Match
                (
                    Right : ok => 
                    {
                        this._statusMessage = "Job is completed.";
                        Output.Add(PSObject.AsPSObject(ok));
                        Output.Complete();
                        SetJobState(JobState.Completed);
                    },
                    Left : err => 
                    {
                        this._statusMessage = $"Job failed: {err.ErrorDetails?.Message ?? err.Exception?.Message ?? "Unknown error"}";
                        Error.Add(err);
                        Error.Complete();
                        SetJobState(JobState.Failed);
                    }
                );
            }
        }
        catch (OperationCanceledException)
        {
            lock (this._lock)
            {
                this._hasMoreData = false;
                this._statusMessage = "Job was canceled.";
                Output.Add(PSObject.AsPSObject("Job was canceled."));
                Output.Complete();
                SetJobState(JobState.Stopped);
            }
        }
        catch (Exception e)
        {
            lock (this._lock)
            {
                this._hasMoreData = false;
                this._statusMessage = $"Job failed: {e.Message}";
                Error.Add(new ErrorRecord(e, "Processing failure.", ErrorCategory.InvalidOperation, this));
                Error.Complete();
                SetJobState(JobState.Failed);
            }
        }
    }
}