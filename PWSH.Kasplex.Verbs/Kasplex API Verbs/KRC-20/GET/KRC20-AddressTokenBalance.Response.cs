namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20AddressTokenBalance
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public List<TokenBalanceSchema>? Result { get; set; } = [];
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class TokenBalanceSchema
    {
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
