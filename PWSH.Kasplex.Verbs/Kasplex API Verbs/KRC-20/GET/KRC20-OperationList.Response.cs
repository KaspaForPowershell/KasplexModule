namespace PWSH.Kasplex.Verbs;

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
        public string? P { get; set; }

        [JsonPropertyName("op")]
        public string? Op { get; set; }

        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

        [JsonPropertyName("max")]
        public string? Max { get; set; }

        [JsonPropertyName("lim")]
        public string? Lim { get; set; }

        [JsonPropertyName("pre")]
        public string? Pre { get; set; }

        [JsonPropertyName("dec")]
        public string? Dec { get; set; }

        [JsonPropertyName("mod")]
        public string? Mod { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }

        [JsonPropertyName("opScore")]
        public string? OpScore { get; set; }

        [JsonPropertyName("hashRev")]
        public string? HashRev { get; set; }

        [JsonPropertyName("feeRev")]
        public string? FeeRev { get; set; }

        [JsonPropertyName("txAccept")]
        public string? TxAccept { get; set; }

        [JsonPropertyName("opAccept")]
        public string? OpAccept { get; set; }

        [JsonPropertyName("opError")]
        public string? OpError { get; set; }

        [JsonPropertyName("mtsAdd")]
        public string? MtsAdd { get; set; }

        [JsonPropertyName("mtsMod")]
        public string? MtsMod { get; set; }

        [JsonPropertyName("checkpoint")]
        public string? Checkpoint { get; set; }

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
                Pre.CompareString(other.Pre) &&
                Dec.CompareString(other.Dec) &&
                Mod.CompareString(other.Mod) &&
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
                Checkpoint.CompareString(other.Checkpoint);
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
            var hash = HashCode.Combine(P, Op, Tick, Max, Lim, Pre, Dec, Mod);
            hash = HashCode.Combine(hash, From, To, OpScore, HashRev, FeeRev, TxAccept, OpAccept);
            return HashCode.Combine(hash, OpError, MtsAdd, Checkpoint);
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
