namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20TokenBlackList
{
    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = true, HelpMessage = "Contract address of the token (case-insensitive).")]
    public string? ContractAddress { get; set; }

    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = false, HelpMessage = "Filtered by address (case-insensitive).")]
    public string? Address { get; set; }

    [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
    public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

    [Parameter(Mandatory = false)]
    public SwitchParameter AsJob { get; set; }
}
