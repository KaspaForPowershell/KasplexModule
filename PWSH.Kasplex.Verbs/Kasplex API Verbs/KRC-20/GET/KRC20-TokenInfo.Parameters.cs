namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenInfo
{
    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = true)]
    public string? TokenName { get; set; }

    [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
    public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

    [Parameter(Mandatory = false)]
    public SwitchParameter AsJob { get; set; }
}
