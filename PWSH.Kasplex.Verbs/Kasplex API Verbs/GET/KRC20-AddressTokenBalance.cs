namespace PWSH.Kasplex.Verbs;

/// <summary>
/// Get balance of a KRC-20 token for an address.
/// </summary>
[Cmdlet(KasplexVerbNames.KRC20, "AddressTokenBalance")]
[OutputType(typeof(ResponseSchema))]
public sealed partial class KRC20AddressTokenBalance : KasplexPSCmdlet
{
    private KasplexJob<ResponseSchema>? _job;

/* -----------------------------------------------------------------
CONSTRUCTORS                                                       |
----------------------------------------------------------------- */

    public KRC20AddressTokenBalance()
    {
        this._httpClient = KasplexModuleInitializer.Instance?.HttpClient;
        this._deserializerOptions = KasplexModuleInitializer.Instance?.ResponseDeserializer;

        if (this._httpClient is null || this._deserializerOptions is null)
            ThrowTerminatingError(new ErrorRecord(new NullReferenceException(), "NullHttpClient", ErrorCategory.InvalidOperation, this));
    }

/* -----------------------------------------------------------------
PROCESS                                                            |
----------------------------------------------------------------- */

    protected override void BeginProcessing()
    {
        async Task<Either<ErrorRecord, ResponseSchema>> processLogic(CancellationToken cancellation_token) { return await DoProcessLogicAsync(this._httpClient!, this._deserializerOptions!, cancellation_token); }

        var thisName = this.MyInvocation.MyCommand.Name;
        this._job = new KasplexJob<ResponseSchema>(processLogic, thisName);
    }

    protected override void ProcessRecord()
    {
        var stoppingToken = this.CreateStoppingToken();

        if (AsJob.IsPresent)
        {
            if (this._job is null)
            {
                WriteError(new ErrorRecord(new NullReferenceException("The job was not initialized."), "JobExecutionFailure", ErrorCategory.InvalidOperation, this));
                return;
            }

            JobRepository.Add(this._job);
            WriteObject(this._job);

            var jobTask = Task.Run(async () => await this._job.ProcessJob(stoppingToken));
            jobTask.ContinueWith(t =>
            {
                if (t.Exception is not null) WriteError(new ErrorRecord(t.Exception, "JobExecutionFailure", ErrorCategory.OperationStopped, this));
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
        else
        {
            var result = DoProcessLogicAsync(this._httpClient!, this._deserializerOptions!, stoppingToken).GetAwaiter().GetResult();
            result.Match
            (
                Right: ok => WriteObject(ok),
                Left: err => WriteError(err)
            );
        }
    }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

    protected override string BuildQuery()
        => $"/krc20/address/{Address}/token/{TokenName}";

    private async Task<Either<ErrorRecord, ResponseSchema>> DoProcessLogicAsync(HttpClient http_client, JsonSerializerOptions deserializer_options, CancellationToken cancellation_token)
    {
        try
        {
            var response = await http_client.SendRequestAsync(this, Globals.KASPLEX_API_ADDRESS, BuildQuery(), HttpMethod.Get, null, TimeoutSeconds, cancellation_token);
            return await response.MatchAsync
            (
                RightAsync: async ok => await ok.ProcessResponseAsync<ResponseSchema>(deserializer_options, this, TimeoutSeconds, cancellation_token),
                Left: err => err
            );
        }
        catch (OperationCanceledException)
        { return new ErrorRecord(new OperationCanceledException("Task was canceled."), "TaskCanceled", ErrorCategory.OperationStopped, this); }
        catch (Exception e)
        { return new ErrorRecord(e, "TaskInvalid", ErrorCategory.InvalidOperation, this); }
    }
}
