namespace SpyderMcp.Server.Models;

public class SpyderConnectionResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public SpyderServerInfo? ServerInfo { get; set; }
}
