namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveVspcList
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
        [JsonPropertyName("chainBlock")]
        public ChainBlockSchema? ChainBlock { get; set; }

        [JsonPropertyName("txList")]
        public List<TransactionSchema>? TxList { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ChainBlockSchema
    {
        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        [JsonPropertyName("daascore")]
        public long DaaScore { get; set; }

        [JsonPropertyName("header")]
        public string? Header { get; set; }

        [JsonPropertyName("verbose")]
        public string? Verbose { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class TransactionSchema
    {
        [JsonPropertyName("txid")]
        public string? TxID { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }
    }
}
