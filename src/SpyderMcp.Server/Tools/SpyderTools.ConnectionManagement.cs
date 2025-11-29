using System.ComponentModel;
using ModelContextProtocol.Server;
using Spyder.Client;
using Spyder.Client.Net;
using SpyderMcp.Server.Models;

namespace SpyderMcp.Server.Tools;

/// <summary>
/// MCP tools for interacting with Spyder video processors.
/// Add your Spyder-specific tools here using the SpyderClientLibrary.
/// </summary>
[McpServerToolType]
public static partial class SpyderTools
{
    [McpServerTool(Name = "spyder_discover")]
    [Description("Discover Spyder servers on the network")]
    public static async Task<SpyderServerInfo[]> DiscoverSpyderServers()
    {
        return [.. _serverList.Values];
    }

    [McpServerTool(Name = "spyder_connect_to_server")]
    [Description("Connect to a Spyder server - should be done before calling other methods except spyder_discover")]
    public static async Task<SpyderConnectionResult> ConnectToSpyder(string serverAddress)
    {
        if(!_serverList.ContainsKey(serverAddress))
        {
            return new SpyderConnectionResult
            {
                Success = false,
                Message = $"Spyder server at {serverAddress} not found on the network"
            };
        }

        var serverInfo = _serverList[serverAddress];
        _currentServer = new SpyderUdpClient(serverInfo.HardwareType, serverInfo.ServerIP);
        if(!await _currentServer.StartupAsync())
        {
            _currentServer = null;
            return new SpyderConnectionResult
            {
                Success = false,
                Message = $"Failed to start Spyder client for server at {serverAddress}"
            };
        }

        return new SpyderConnectionResult
        {
            Success = true,
            Message = $"Connected to Spyder server at {serverAddress}",
            ServerInfo = serverInfo,
        };
    }
}
