namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveOperationList
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("result")]
        public List<ResultSchema>? Result { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResultSchema
    {

        [JsonPropertyName("opScore")]
        public string? OpScore { get; set; }

        [JsonPropertyName("addressaffc")]
        public string? AddressAffc { get; set; }

        [JsonPropertyName("script")]
        public string? Script { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("tickaffc")]
        public string? TickAffc { get; set; }

        [JsonPropertyName("txid")]
        public string? TxID { get; set; }
    }
}
