namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenList
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
                Mod.CompareString(other.Mod) &&
                Minted.CompareString(other.Minted) &&
                Burned.CompareString(other.Burned) &&
                OpScoreAdd.CompareString(other.OpScoreAdd) &&
                OpScoreMod.CompareString(other.OpScoreMod) &&
                State.CompareString(other.State) &&
                HashRev.CompareString(other.HashRev) &&
                MtsAdd.CompareString(other.MtsAdd);
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
            var hash = HashCode.Combine(Tick, Max, Lim, Pre, To, Dec, Mod, Minted);
            return HashCode.Combine(hash, Burned, OpScoreAdd, OpScoreMod, State, HashRev, MtsAdd);
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
