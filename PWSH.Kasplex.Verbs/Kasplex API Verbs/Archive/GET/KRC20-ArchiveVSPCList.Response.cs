namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveVspcList
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
        [JsonPropertyName("chainBlock")]
        public ChainBlockSchema? ChainBlock { get; set; }

        [JsonPropertyName("txList")]
        public List<TransactionSchema>? TxList { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(ResultSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                ChainBlock == other.ChainBlock &&
                TxList.CompareList(other.TxList);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as ResultSchema);

        public override int GetHashCode()
        {
            var hash = HashCode.Combine(ChainBlock);
            return TxList.GenerateHashCode(hash);
        }

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

    private sealed class ChainBlockSchema : IEquatable<ChainBlockSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        [JsonPropertyName("daascore")]
        public long DaaScore { get; set; }

        [JsonPropertyName("header")]
        public string? Header { get; set; }

        [JsonPropertyName("verbose")]
        public string? Verbose { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(ChainBlockSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                Hash.CompareString(other.Hash) &&
                DaaScore == other.DaaScore &&
                Header.CompareString(other.Header) &&
                Verbose.CompareString(other.Verbose);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as ChainBlockSchema);

        public override int GetHashCode()
            => HashCode.Combine(Hash, DaaScore, Header, Verbose);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

        public static bool operator ==(ChainBlockSchema? left, ChainBlockSchema? right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(ChainBlockSchema? left, ChainBlockSchema? right)
            => !(left == right);
    }

    private sealed class TransactionSchema : IEquatable<TransactionSchema>, IJSONableDisplayable
    {
        [JsonPropertyName("txid")]
        public string? TxID { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

/* -----------------------------------------------------------------
HELPERS                                                            |
----------------------------------------------------------------- */

        public bool Equals(TransactionSchema? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                TxID.CompareString(other.TxID) &&
                Data.CompareString(other.Data);
        }

        public string ToJSON()
            => JsonSerializer.Serialize(this, KasplexModuleInitializer.Instance?.ResponseSerializer);

/* -----------------------------------------------------------------
OVERRIDES                                                          |
----------------------------------------------------------------- */

        public override bool Equals(object? obj)
            => Equals(obj as TransactionSchema);

        public override int GetHashCode()
            => HashCode.Combine(TxID, Data);

/* -----------------------------------------------------------------
OPERATOR                                                           |
----------------------------------------------------------------- */

        public static bool operator ==(TransactionSchema? left, TransactionSchema? right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(TransactionSchema? left, TransactionSchema? right)
            => !(left == right);
    }
}
