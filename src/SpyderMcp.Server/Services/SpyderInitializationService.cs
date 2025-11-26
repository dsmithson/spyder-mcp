using Microsoft.Extensions.Hosting;
using Spyder.Client;
using Spyder.Client.Net.Notifications;

namespace SpyderMcp.Server.Services;

/// <summary>
/// Hosted service that initializes the SpyderClientManager during application startup.
/// </summary>
public class SpyderInitializationService : IHostedService
{
    private readonly SpyderServerEventListener _serverEventListener;

    public SpyderInitializationService(SpyderServerEventListener serverEventListener)
    {
        _serverEventListener = serverEventListener;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _serverEventListener.StartupAsync();
        
        // Allow some time for network discovery
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if(_serverEventListener != null && _serverEventListener.IsRunning)
        {
            await _serverEventListener.ShutdownAsync();
        }
    }
}
