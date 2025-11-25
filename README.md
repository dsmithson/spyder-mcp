# Spyder MCP Server

A Model Context Protocol (MCP) server for Spyder video processors, built with .NET 10. This server enables AI assistants like Claude Desktop, ChatGPT, and others to interact with Spyder video processing systems through a standardized protocol.

## Overview

This project provides an MCP server that uses stdio transport for local connections, making it easy to integrate with AI desktop applications. Under the covers, it uses the [SpyderClientLibrary](https://www.nuget.org/packages/SpyderClientLibrary) NuGet package ([GitHub](https://github.com/dsmithson/SpyderClientLibrary)) for communicating with Spyder hardware.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Building

```bash
# Clone the repository
git clone https://github.com/dsmithson/spyder-mcp.git
cd spyder-mcp

# Build the solution
dotnet build
```

## Running

```bash
dotnet run --project src/SpyderMcp.Server
```

## Configuration for Claude Desktop

Add the following to your Claude Desktop configuration file:

**Windows:** `%APPDATA%\Claude\claude_desktop_config.json`  
**macOS:** `~/Library/Application Support/Claude/claude_desktop_config.json`

```json
{
  "mcpServers": {
    "spyder": {
      "command": "dotnet",
      "args": ["run", "--project", "/path/to/spyder-mcp/src/SpyderMcp.Server"]
    }
  }
}
```

Or, if you've published the application:

```json
{
  "mcpServers": {
    "spyder": {
      "command": "/path/to/SpyderMcp.Server"
    }
  }
}
```

## Adding Tools

Tools are located in the `src/SpyderMcp.Server/Tools` folder. To add a new tool:

1. Open `SpyderTools.cs` (or create a new class file)
2. Add a static method with the `[McpServerTool]` attribute
3. Add a `[Description]` attribute to describe what the tool does
4. Use the SpyderClientLibrary to implement the tool functionality

Example:

```csharp
[McpServerTool]
[Description("Connect to a Spyder server and retrieve system status")]
public static async Task<string> GetSpyderStatus(string serverAddress, int port = 11116)
{
    // Use SpyderClientLibrary here
    return $"Status from {serverAddress}:{port}";
}
```

## Project Structure

```
spyder-mcp/
├── src/
│   └── SpyderMcp.Server/
│       ├── Program.cs           # MCP server entry point
│       ├── Tools/
│       │   └── SpyderTools.cs   # Spyder-specific MCP tools
│       └── SpyderMcp.Server.csproj
├── SpyderMcp.sln
├── README.md
└── LICENSE
```

## Dependencies

- [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol) - Official MCP SDK for .NET
- [SpyderClientLibrary](https://www.nuget.org/packages/SpyderClientLibrary) - Library for communicating with Spyder video processors

## License

Apache License 2.0 - See [LICENSE](LICENSE) for details.