namespace PWSH.Kasplex.Verbs;

public sealed partial class GetNodeStatus
{
    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResponseSchema
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("result")]
        public ResultSchema? Result { get; set; }
    }

    [GenerateResponseSchemaBoilerplate]
    private sealed partial class ResultSchema
    {
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("versionApi")]
        public string? VersionAPI { get; set; }

        [JsonPropertyName("daaScore")]
        public string? DaaScore { get; set; }

        [JsonPropertyName("daaScoreGap")]
        public string? DaaScoreGap { get; set; }

        [JsonPropertyName("opScore")]
        public string? OpScore { get; set; }

        [JsonPropertyName("opTotal")]
        public string? OpTotal { get; set; }

        [JsonPropertyName("tokenTotal")]
        public string? TokenTotal { get; set; }

        [JsonPropertyName("feeTotal")]
        public string? FeeTotal { get; set; }
    }
}
