namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20OperationInfo
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("result")]
        public OperationSchema? Result { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class OperationSchema
    {
        [JsonPropertyName("p")]
        public string? P { get; set; }

        [JsonPropertyName("op")]
        public string? Op { get; set; }

        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

        [JsonPropertyName("amt")]
        public string? Amt { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("utxo")]
        public string? UTXO { get; set; }

        [JsonPropertyName("opScore")]
        public string? OpScore { get; set; }

        [JsonPropertyName("hashRev")]
        public string? HashRev { get; set; }

        [JsonPropertyName("feeRev")]
        public string? FeeRev { get; set; }

        [JsonPropertyName("txAccept")]
        public string? TxAccept { get; set; }

        [JsonPropertyName("opAccept")]
        public string? OpAccept { get; set; }

        [JsonPropertyName("opError")]
        public string? OpError { get; set; }

        [JsonPropertyName("mtsAdd")]
        public string? MtsAdd { get; set; }

        [JsonPropertyName("mtsMod")]
        public string? MtsMod { get; set; }

        [JsonPropertyName("checkpoint")]
        public string? Checkpoint { get; set; }
    }
}
