using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using Spyder.Client;
using Spyder.Client.Net.Notifications;
using SpyderMcp.Server;
using SpyderMcp.Server.Services;
using SpyderMcp.Server.Tools;

// CRITICAL: Use CreateEmptyApplicationBuilder to avoid default console logging
var builder = Host.CreateEmptyApplicationBuilder(settings: null);

// Add file logging for development (optional)
//builder.Logging.AddFile("C:\\Temp\\spyder-mcp.log");
//builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Register our ServerEventListener as a singleton
builder.Services.AddSingleton<SpyderServerEventListener>();

// Register the hosted service for async initialization
builder.Services.AddHostedService<SpyderInitializationService>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

// Initialize SpyderTools with the ServerEventListener
var serverEventListener = app.Services.GetRequiredService<SpyderServerEventListener>();
SpyderTools.Initialize(serverEventListener);

await app.RunAsync();