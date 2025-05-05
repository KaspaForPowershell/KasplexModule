namespace PWSH.Kasplex.Verbs;

public sealed partial class KRC20OperationInfo
{
    [ValidateNotNullOrEmpty]
    [Parameter(Mandatory = true, HelpMessage = "OP score or reveal transaction ID.")]
    public string? OperationID { get; set; }

    [Parameter(Mandatory = false, HelpMessage = "Http client timeout.")]
    public ulong TimeoutSeconds { get; set; } = Globals.DEFAULT_TIMEOUT_SECONDS;

    [Parameter(Mandatory = false)]
    public SwitchParameter AsJob { get; set; }
}
