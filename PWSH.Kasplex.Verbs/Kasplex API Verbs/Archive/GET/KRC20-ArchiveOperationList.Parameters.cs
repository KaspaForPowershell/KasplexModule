namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveOperationList
{
    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = true, HelpMessage = "DAA score range corresponding to operations (DaaScore/10 truncate to integer).")]
    public string? OPrange { get; set; }

    [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
    public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

    [Parameter(Mandatory = false)]
    public SwitchParameter AsJob { get; set; }
}
