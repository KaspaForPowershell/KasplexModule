namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenMarketInfo
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
        public List<TokenInfoSchema>? Result { get; set; }

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

    private sealed class TokenInfoSchema : IEquatable<TokenInfoSchema>, IJSONableDisplayable
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

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(TokenInfoSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                ContractAddress.CompareString(other.ContractAddress) &&
                Tick.CompareString(other.Tick) &&
                From.CompareString(other.From) &&
                Amount.CompareString(other.Amount) &&
                uTxID.CompareString(other.uTxID) &&
                uAddr.CompareString(other.uAddr) &&
                uAmt.CompareString(other.uAmt) &&
                uScript.CompareString(other.uScript) &&
                OpScoreAdd.CompareString(other.OpScoreAdd);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as TokenInfoSchema);
        public override int GetHashCode()
        {
            var hash = HashCode.Combine(ContractAddress, Tick, From, Amount, uTxID);
            return HashCode.Combine(hash, uAddr, uAmt, uScript, OpScoreAdd);
        }

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

        public static bool operator ==(TokenInfoSchema? left, TokenInfoSchema? right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(TokenInfoSchema? left, TokenInfoSchema? right)
            => !(left == right);
    }
}
