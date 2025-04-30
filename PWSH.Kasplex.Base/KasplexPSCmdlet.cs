namespace PWSH.Kasplex.Base
{
    public abstract class KasplexPSCmdlet : PSCmdlet
    {
        protected HttpClient? _httpClient;
        protected HttpResponseMessage? _response;
        protected JsonSerializerOptions? _deserializerOptions;

        protected virtual string BuildQuery()
            => string.Empty;
    }
}