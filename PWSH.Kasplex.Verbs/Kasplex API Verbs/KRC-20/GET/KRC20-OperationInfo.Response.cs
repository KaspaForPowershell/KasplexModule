namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20OperationInfo
{
    private sealed class ResponseSchema : IEquatable<ResponseSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("result")]
        public OperationSchema? Result { get; set; }

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

    private sealed class OperationSchema : IEquatable<OperationSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("p")]
        public string? P { get; set; }

        [JsonPropertyName("op")]
        public string? Op { get; set; }

        [JsonPropertyName("tick")]
        public string? Tick { get; set; }

        [JsonPropertyName("amt")]
        public string? Amt { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("utxo")]
        public string? UTXO { get; set; }

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
                Amt.CompareString(other.Amt) &&
                From.CompareString(other.From) &&
                UTXO.CompareString(other.UTXO) &&
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
            var hash = HashCode.Combine(P, Op, Tick, Amt, From, UTXO);
            hash = HashCode.Combine(hash, OpScore, HashRev, FeeRev, TxAccept, OpAccept);
            return HashCode.Combine(hash, OpError, MtsAdd, MtsMod, Checkpoint);
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
