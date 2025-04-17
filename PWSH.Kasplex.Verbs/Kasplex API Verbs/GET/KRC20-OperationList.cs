﻿using System.Management.Automation;
using System.Text.Json;
using System.Web;
using PWSH.Kasplex.Base;
using PWSH.Kasplex.Constants;

using LanguageExt;
using static LanguageExt.Prelude;

namespace PWSH.Kasplex.Verbs
{
    /// <summary>
    /// Get list of KRC-20 operations.
    /// </summary>
    [Cmdlet(KasplexVerbNames.KRC20, "OperationList")]
    [OutputType(typeof(ResponseSchema))]
    public sealed partial class KRC20OperationList : KasplexPSCmdlet
    {
        private KasplexJob<List<ResponseSchema>>? _job;

/* -----------------------------------------------------------------
CONSTRUCTORS                                                       |
----------------------------------------------------------------- */

        public KRC20OperationList()
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
            async Task<Either<ErrorRecord, List<ResponseSchema>>> processLogic(CancellationToken cancellation_token) { return await DoProcessLogicAsync(this._httpClient!, this._deserializerOptions!, cancellation_token); }

            var thisName = this.MyInvocation.MyCommand.Name;
            this._job = new KasplexJob<List<ResponseSchema>>(processLogic, thisName);
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

        private string BuildQuery(string? next_page)
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["address"] = Address;

            if (TokenName is not null) queryParams["tick"] = TokenName;
            if (!string.IsNullOrEmpty(next_page)) queryParams["next"] = next_page;

            return "/krc20/oplist?" + queryParams.ToString();
        }

        private async Task<Either<ErrorRecord, List<ResponseSchema>>> DoProcessLogicAsync(HttpClient http_client, JsonSerializerOptions deserializer_options, CancellationToken cancellation_token)
        {
            try
            {
                var allTokens = new List<ResponseSchema>();
                string? nextCursor = null;

                do
                {
                    var result = await http_client.SendRequestAsync(this, Globals.KASPLEX_API_ADDRESS, BuildQuery(nextCursor), HttpMethod.Get, null, TimeoutSeconds, cancellation_token);
                    if (result.IsLeft)
                        return result.LeftToList()[0];

                    var response = result.RightToList()[0];
                    var message = await response.ProcessResponseAsync<ResponseSchema>(deserializer_options, this, TimeoutSeconds, cancellation_token);
                    if (message.IsLeft)
                        return message.LeftToList()[0];

                    allTokens.Add(message.RightToList()[0]);
                    nextCursor = message.RightToList()[0].Next;

                } while (!string.IsNullOrEmpty(nextCursor) && !cancellation_token.IsCancellationRequested);

                return Right<ErrorRecord, List<ResponseSchema>>(allTokens);
            }
            catch (OperationCanceledException)
            { return Left<ErrorRecord, List<ResponseSchema>>(new ErrorRecord(new OperationCanceledException("Task was canceled."), "TaskCanceled", ErrorCategory.OperationStopped, this)); }
            catch (Exception e)
            { return Left<ErrorRecord, List<ResponseSchema>>(new ErrorRecord(e, "TaskInvalid", ErrorCategory.InvalidOperation, this)); }
        }
    }
}
