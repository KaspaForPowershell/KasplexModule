namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20AddressTokenBalances
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
        public List<TokenBalanceSchema>? Result { get; set; }

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

    private sealed class TokenBalanceSchema : IEquatable<TokenBalanceSchema>, IJSONableDisplayable
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

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(TokenBalanceSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                Tick.CompareString(other.Tick) &&
                Balance.CompareString(other.Balance) &&
                Locked.CompareString(other.Locked) &&
                Dec.CompareString(other.Dec) &&
                OpScoreMod.CompareString(other.OpScoreMod);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as TokenBalanceSchema);

        public override int GetHashCode()
            => HashCode.Combine(Tick, Balance, Locked, Dec, OpScoreMod);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

        public static bool operator ==(TokenBalanceSchema? left, TokenBalanceSchema? right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(TokenBalanceSchema? left, TokenBalanceSchema? right)
            => !(left == right);
    }
}
