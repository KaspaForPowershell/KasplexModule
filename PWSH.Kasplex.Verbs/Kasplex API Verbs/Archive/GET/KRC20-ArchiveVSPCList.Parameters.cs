namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20ArchiveVspcList
{
    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = true, HelpMessage = "Vspc-block DAA score.")]
    public string? DaaScore { get; set; }

    [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
    public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

    [Parameter(Mandatory = false)]
    public SwitchParameter AsJob { get; set; }
}
