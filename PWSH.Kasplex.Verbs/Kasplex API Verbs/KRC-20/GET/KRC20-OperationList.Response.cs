namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20OperationList
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("prev")]
        public string? Prev { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("result")]
        public List<OperationSchema>? Result { get; set; }
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

        [JsonPropertyName("max")]
        public string? Max { get; set; }

        [JsonPropertyName("lim")]
        public string? Lim { get; set; }

        [JsonPropertyName("pre")]
        public string? Pre { get; set; }

        [JsonPropertyName("dec")]
        public string? Dec { get; set; }

        [JsonPropertyName("mod")]
        public string? Mod { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }

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
