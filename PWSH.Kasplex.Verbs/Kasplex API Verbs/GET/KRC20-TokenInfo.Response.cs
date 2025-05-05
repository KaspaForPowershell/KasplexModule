namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenInfo
{
    private sealed class ResponseSchema : IEquatable<ResponseSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public List<TokenInfoSchema>? Result { get; set; } = new();

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(ResponseSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                Message.CompareString(other.Message) &&
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
        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

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

        [JsonPropertyName("minted")]
        public string? Minted { get; set; }

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

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(TokenInfoSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                Tick.CompareString(other.Tick) &&
                Max.CompareString(other.Max) &&
                Lim.CompareString(other.Lim) &&
                Pre.CompareString(other.Pre) &&
                To.CompareString(other.To) &&
                Dec.CompareString(other.Dec) &&
                Minted.CompareString(other.Minted) &&
                OpScoreAdd.CompareString(other.OpScoreAdd) &&
                OpScoreMod.CompareString(other.OpScoreMod) &&
                State.CompareString(other.State) &&
                HashRev.CompareString(other.HashRev) &&
                MtsAdd.CompareString(other.MtsAdd) &&
                HolderTotal.CompareString(other.HolderTotal) &&
                TransferTotal.CompareString(other.TransferTotal) &&
                MintTotal.CompareString(other.MintTotal) &&
                Holder.CompareList(other.Holder);
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
            var hash = HashCode.Combine(Tick, Max, Lim, Pre, To, Dec, Minted, OpScoreAdd);
            hash = HashCode.Combine(hash, OpScoreMod, State, HashRev, MtsAdd, HolderTotal, TransferTotal, MintTotal);
            return Holder.GenerateHashCode(hash);
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

    public class TokenHolderSchema : IEquatable<TokenHolderSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(TokenHolderSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                Address.CompareString(other.Address) &&
                Amount.CompareString(other.Amount);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as TokenHolderSchema);

        public override int GetHashCode()
            => HashCode.Combine(Address, Amount);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

        public static bool operator ==(TokenHolderSchema? left, TokenHolderSchema? right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(TokenHolderSchema? left, TokenHolderSchema? right)
            => !(left == right);
    }
}
