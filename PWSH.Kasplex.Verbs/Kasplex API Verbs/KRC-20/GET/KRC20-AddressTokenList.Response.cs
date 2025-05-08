namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20AddressTokenList
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
        public List<TokenBalanceSchema>? Result { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class TokenBalanceSchema
    {
        [JsonPropertyName("ca")]
        public string? ContractAddress { get; set; }

        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

        [JsonPropertyName("balance")]
        public string? Balance { get; set; }

        [JsonPropertyName("locked")]
        public string? Locked { get; set; }

        [JsonPropertyName("dec")]
        public string? Dec { get; set; }

        [JsonPropertyName("opScoreMod")]
        public string? OpScoreMod { get; set; }
    }
}
