namespace PWSH.Kasplex.Verbs
{
    public sealed partial class KRC20ListingList
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public string? TokenName { get; set; }

        [ValidateKaspaAddress]
        [Parameter(Mandatory = false, HelpMessage = "Kaspa address as string e.g. kaspa:qqkqkzjvr7zwxxmjxjkmxxdwju9kjs6e9u82uh59z07vgaks6gg62v8707g73")]
        public string? Address { get; set; } = null;

        [ValidateKaspaTransactionID]
        [Parameter(Mandatory = false)]
        public string? TransactionID { get; set; } = null;

        [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
        public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

        [Parameter(Mandatory = false)]
        public SwitchParameter AsJob { get; set; }
    }
}
