using System.Text.Json;
using System.Text.Json.Serialization;
using PWSH.Kasplex.Base;
using PWSH.Kasplex.Base.JSON.Interfaces;

namespace PWSH.Kasplex.Verbs
{
    public sealed partial class GetIndexerStatus
    {
        private sealed class ResponseSchema : IEquatable<ResponseSchema>, IJSONableDisplayable
        {
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("result")]
            public ResultSchema? Result { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

            public bool Equals(ResponseSchema? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;

                return
                    Message.CompareString(other.Message) &&
                    Result == other.Result;
            }

            public string ToJSON()
                => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

            public override bool Equals(object? obj)
                => Equals(obj as ResponseSchema);

            public override int GetHashCode()
                => HashCode.Combine(Message, Result);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

            public static bool operator ==(ResponseSchema? left, ResponseSchema? right)
            {
                if (left is null) return right is null;

                return left.Equals(right);
            }

            public static bool operator !=(ResponseSchema? left, ResponseSchema? right)
                => !(left == right);
        }

        private sealed class ResultSchema : IEquatable<ResultSchema>, IJSONableDisplayable
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

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

            public bool Equals(ResultSchema? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;

                return
                    Version.CompareString(other.Version) &&
                    VersionAPI.CompareString(other.VersionAPI) &&
                    DaaScore.CompareString(other.DaaScore) &&
                    DaaScoreGap.CompareString(other.DaaScoreGap) &&
                    OpScore.CompareString(other.OpScore) &&
                    OpTotal.CompareString(other.OpTotal) &&
                    TokenTotal.CompareString(other.TokenTotal) &&
                    FeeTotal.CompareString(other.FeeTotal);
            }

            public string ToJSON()
                => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

            public override bool Equals(object? obj)
                => Equals(obj as ResultSchema);

            public override int GetHashCode()
                => HashCode.Combine(Version, VersionAPI, DaaScore, DaaScoreGap, OpScore, OpTotal, TokenTotal, FeeTotal);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

            public static bool operator ==(ResultSchema? left, ResultSchema? right)
            {
                if (left is null) return right is null;

                return left.Equals(right);
            }

            public static bool operator !=(ResultSchema? left, ResultSchema? right)
                => !(left == right);
        }
    }
}
