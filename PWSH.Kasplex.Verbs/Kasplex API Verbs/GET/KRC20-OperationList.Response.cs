using System.Text.Json;
using System.Text.Json.Serialization;
using PWSH.Kasplex.Base;
using PWSH.Kasplex.Base.JSON.Interfaces;

namespace PWSH.Kasplex.Verbs
{
    public sealed partial class KRC20OperationList
    {
        private sealed class ResponseSchema : IEquatable<ResponseSchema>, IJSONableDisplayable
        {
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("prev")]
            public string? Prev { get; set; }

            [JsonPropertyName("next")]
            public string? Next { get; set; }

            [JsonPropertyName("result")]
            public List<OperationSchema>? Result { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

            public bool Equals(ResponseSchema? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;

                return
                    Message.CompareString(other.Message) &&
                    Prev.CompareString(other.Prev) &&
                    Next.CompareString(other.Next) &&
                    Result.CompareList(other.Result);
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

        private sealed class OperationSchema : IEquatable<OperationSchema>, IJSONableDisplayable
        {
            [JsonPropertyName("p")]
            public string P { get; set; } = string.Empty;

            [JsonPropertyName("op")]
            public string Op { get; set; } = string.Empty;

            [JsonPropertyName("tick")]
            public string Tick { get; set; } = string.Empty;

            [JsonPropertyName("max")]
            public string Max { get; set; } = string.Empty;

            [JsonPropertyName("lim")]
            public string Lim { get; set; } = string.Empty;

            [JsonPropertyName("dec")]
            public string Dec { get; set; } = string.Empty;

            [JsonPropertyName("pre")]
            public string Pre { get; set; } = string.Empty;

            [JsonPropertyName("amt")]
            public string Amt { get; set; } = string.Empty;

            [JsonPropertyName("from")]
            public string From { get; set; } = string.Empty;

            [JsonPropertyName("to")]
            public string To { get; set; } = string.Empty;

            [JsonPropertyName("opScore")]
            public string OpScore { get; set; } = string.Empty;

            [JsonPropertyName("hashRev")]
            public string HashRev { get; set; } = string.Empty;

            [JsonPropertyName("feeRev")]
            public string FeeRev { get; set; } = string.Empty;

            [JsonPropertyName("txAccept")]
            public string TxAccept { get; set; } = string.Empty;

            [JsonPropertyName("opAccept")]
            public string OpAccept { get; set; } = string.Empty;

            [JsonPropertyName("opError")]
            public string OpError { get; set; } = string.Empty;

            [JsonPropertyName("mtsAdd")]
            public string MtsAdd { get; set; } = string.Empty;

            [JsonPropertyName("mtsMod")]
            public string MtsMod { get; set; } = string.Empty;

            [JsonPropertyName("utxo")]
            public string UTXO { get; set; } = string.Empty;

            [JsonPropertyName("price")]
            public string Price { get; set; } = string.Empty;

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

            public bool Equals(OperationSchema? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;

                return
                    P.CompareString(other.P) &&
                    Op.CompareString(other.Op) &&
                    Tick.CompareString(other.Tick) &&
                    Max.CompareString(other.Max) &&
                    Lim.CompareString(other.Lim) &&
                    Dec.CompareString(other.Dec) &&
                    Pre.CompareString(other.Pre) &&
                    Amt.CompareString(other.Amt) &&
                    From.CompareString(other.From) &&
                    To.CompareString(other.To) &&
                    OpScore.CompareString(other.OpScore) &&
                    HashRev.CompareString(other.HashRev) &&
                    FeeRev.CompareString(other.FeeRev) &&
                    TxAccept.CompareString(other.TxAccept) &&
                    OpAccept.CompareString(other.OpAccept) &&
                    OpError.CompareString(other.OpError) &&
                    MtsAdd.CompareString(other.MtsAdd) &&
                    MtsMod.CompareString(other.MtsMod) &&
                    UTXO.CompareString(other.UTXO) &&
                    Price.CompareString(other.Price);
            }

            public string ToJSON()
                => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

            public override bool Equals(object? obj)
                => Equals(obj as OperationSchema);

            public override int GetHashCode()
            {
                var hash = HashCode.Combine(P, Op, Tick, Max, Lim, Dec, Pre, Amt);
                hash = HashCode.Combine(hash, From, To, OpScore, HashRev, FeeRev, TxAccept, OpAccept);
                return HashCode.Combine(hash, OpError, MtsAdd, UTXO, Price);
            }

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

            public static bool operator ==(OperationSchema? left, OperationSchema? right)
            {
                if (left is null) return right is null;

                return left.Equals(right);
            }

            public static bool operator !=(OperationSchema? left, OperationSchema? right)
                => !(left == right);
        }
    }
}
