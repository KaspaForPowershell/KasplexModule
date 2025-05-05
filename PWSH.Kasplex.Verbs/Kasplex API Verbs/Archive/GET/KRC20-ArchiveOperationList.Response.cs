namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveOperationList
{
    private sealed class ResponseSchema : IEquatable<ResponseSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("result")]
        public List<ResultSchema>? Result { get; set; }

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
        {
            var hash = HashCode.Combine(Message);
            return Result.GenerateHashCode(hash);
        }

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

        [JsonPropertyName("opScore")]
        public string? OpScore { get; set; }

        [JsonPropertyName("addressaffc")]
        public string? AddressAffc { get; set; }

        [JsonPropertyName("script")]
        public string? Script { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("tickaffc")]
        public string? TickAffc { get; set; }

        [JsonPropertyName("txid")]
        public string? TxID { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(ResultSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                OpScore.CompareString(other.OpScore) &&
                AddressAffc.CompareString(other.AddressAffc) &&
                Script.CompareString(other.Script) &&
                State.CompareString(other.State) &&
                TickAffc.CompareString(other.TickAffc) &&
                TxID.CompareString(other.TxID);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as ResultSchema);

        public override int GetHashCode()
            => HashCode.Combine(OpScore, AddressAffc, Script, State, TickAffc, TxID);

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
