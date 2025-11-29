using Spyder.Client.Common;
using Spyder.Client.Net.Notifications;

namespace SpyderMcp.Server.Models;

public class SpyderServerInfo
{
    public string ServerIP { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public HardwareType HardwareType { get; set; }

    public SpyderServerInfo()
    {
    }

    public SpyderServerInfo(SpyderServerAnnounceInformation serverInfo)
    {
        this.ServerIP = serverInfo.Address;
        this.Name = serverInfo.ServerName;
        this.Version = serverInfo.Version.ToString();
        this.HardwareType = serverInfo.HardwareType;
    }
}
