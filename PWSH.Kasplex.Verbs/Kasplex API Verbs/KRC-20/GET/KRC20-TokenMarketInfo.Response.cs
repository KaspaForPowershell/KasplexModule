namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenMarketInfo
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
        public List<TokenInfoSchema>? Result { get; set; }
    }


    [GenerateResponseSchemaBoilerplate]
    private sealed partial class TokenInfoSchema
    {
        [JsonPropertyName("ca")]
        public string? ContractAddress { get; set; }

        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("uTxid")]
        public string? uTxID { get; set; }

        [JsonPropertyName("uAddr")]
        public string? uAddr { get; set; }

        [JsonPropertyName("uAmt")]
        public string? uAmt { get; set; }

        [JsonPropertyName("uScript")]
        public string? uScript { get; set; }

        [JsonPropertyName("opScoreAdd")]
        public string? OpScoreAdd { get; set; }
    }
}
