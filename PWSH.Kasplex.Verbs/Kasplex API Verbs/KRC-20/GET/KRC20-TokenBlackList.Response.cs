namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenBlackList
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
        public List<ResultSchema>? Result { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResultSchema
    {
        [JsonPropertyName("ca")]
        public string? ContractAddress { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("opScoreAdd")]
        public string? OpScoreAdd { get; set; }
    }
}
