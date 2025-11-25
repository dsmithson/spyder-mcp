using System.ComponentModel;
using ModelContextProtocol.Server;

namespace SpyderMcp.Server.Tools;

/// <summary>
/// MCP tools for interacting with Spyder video processors.
/// Add your Spyder-specific tools here using the SpyderClientLibrary.
/// </summary>
[McpServerToolType]
public static class SpyderTools
{
    /// <summary>
    /// Example tool that echoes back the input message.
    /// Replace this with actual Spyder functionality using SpyderClientLibrary.
    /// </summary>
    /// <param name="message">The message to echo back</param>
    /// <returns>The echoed message with a prefix</returns>
    [McpServerTool]
    [Description("Echo a message back - this is a placeholder tool. Replace with actual Spyder tools.")]
    public static string Echo(string message)
    {
        return $"Spyder MCP Echo: {message}";
    }

    // TODO: Add Spyder-specific tools here. Example structure:
    //
    // [McpServerTool]
    // [Description("Connect to a Spyder server")]
    // public static async Task<string> ConnectToSpyder(string serverAddress, int port = 11116)
    // {
    //     // Use SpyderClientLibrary to connect
    //     // var client = new SpyderClient();
    //     // await client.ConnectAsync(serverAddress, port);
    //     return $"Connected to Spyder server at {serverAddress}:{port}";
    // }
    //
    // [McpServerTool]
    // [Description("Get list of available sources")]
    // public static async Task<string> GetSources()
    // {
    //     // Use SpyderClientLibrary to get sources
    //     return "List of sources...";
    // }
    //
    // [McpServerTool]
    // [Description("Switch a layer to a specific source")]
    // public static async Task<string> SwitchSource(string layerName, string sourceName)
    // {
    //     // Use SpyderClientLibrary to switch source
    //     return $"Switched {layerName} to {sourceName}";
    // }
}
