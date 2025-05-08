namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenInfo
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public List<TokenInfoSchema>? Result { get; set; } = [];
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class TokenInfoSchema
    {
        [JsonPropertyName("ca")]
        public string? ContractAddress { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("max")]
        public string? Max { get; set; }

        [JsonPropertyName("lim")]
        public string? Lim { get; set; }

        [JsonPropertyName("pre")]
        public string? Pre { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }

        [JsonPropertyName("dec")]
        public string? Dec { get; set; }

        [JsonPropertyName("mod")]
        public string? Mod { get; set; }

        [JsonPropertyName("minted")]
        public string? Minted { get; set; }

        [JsonPropertyName("burned")]
        public string? Burned { get; set; }

        [JsonPropertyName("opScoreAdd")]
        public string? OpScoreAdd { get; set; }

        [JsonPropertyName("opScoreMod")]
        public string? OpScoreMod { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("hashRev")]
        public string? HashRev { get; set; }

        [JsonPropertyName("mtsAdd")]
        public string? MtsAdd { get; set; }

        [JsonPropertyName("holderTotal")]
        public string? HolderTotal { get; set; }

        [JsonPropertyName("transferTotal")]
        public string? TransferTotal { get; set; }

        [JsonPropertyName("mintTotal")]
        public string? MintTotal { get; set; }

        [JsonPropertyName("holder")]
        public List<TokenHolderSchema>? Holder { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    public sealed partial class TokenHolderSchema
    {
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
    }
}
