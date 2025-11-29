using ModelContextProtocol.Server;
using Spyder.Client;
using Spyder.Client.Common;
using Spyder.Client.Net;
using Spyder.Client.Net.Notifications;
using SpyderMcp.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpyderMcp.Server.Tools
{
    public static partial class SpyderTools
    {
        private static ISpyderClient? _currentServer;
        private static SpyderServerEventListener? _eventListener;
        private readonly static Dictionary<string, SpyderServerInfo> _serverList = [];

        public static void Initialize(SpyderServerEventListener eventListener)
        {
            _eventListener = eventListener;
            _eventListener.ServerAnnounceMessageReceived += OnServerAnnounceMessageReceived;
        }

        private static void OnServerAnnounceMessageReceived(object sender, SpyderServerAnnounceInformation serverInfo)
        {
            _serverList[serverInfo.Address] = new SpyderServerInfo(serverInfo);
        }

        private static async Task<CommandResult<List<RegisterInfo>>> GetRegistersAsync(RegisterType type)
        {
            return await GetMcpDataFromSpyder(
                server => server.GetRegisters(type),
                register => new RegisterInfo(register)
            );
        }

        private static async Task<CommandResult<List<RegisterPageInfo>>> GetRegisterPagesAsync(RegisterType type)
        {
            return await GetMcpDataFromSpyder(
                server => server.GetRegisterPages(type),
                page => new RegisterPageInfo(page)
            );
        }

        private static async Task<CommandResult<List<U>>> GetMcpDataFromSpyder<T,U>(Func<ISpyderClient, Task<List<T>>> dataFetcher, Func<T, U> convert)
        {
            var response = new CommandResult<List<U>>();
            if (_currentServer == null)
            {
                response.Success = false;
                response.Message = "No Spyder server connected.";
                return response;
            }
            try
            {
                IList<T> data = await dataFetcher(_currentServer);
                if (data == null)
                {
                    response.Success = false;
                    response.Message = "No data found.";
                    return response;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Data retrieved successfully.";
                    response.Data = [.. data.Select(d => convert(d))];
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving data: {ex.Message}";
            }
            return response;
        }

        private static async Task<CommandResult> RunSpyderCommandForMcp(Func<ISpyderClient, Task<bool>> commandRunner, string? successMessage = null, string? failureMessage = null)
        {
            var response = new CommandResult();
            if (_currentServer == null)
            {
                response.Success = false;
                response.Message = "No Spyder server connected.";
                return response;
            }
            try
            {
                bool success = await commandRunner(_currentServer);
                response.Success = success;
                if (success)
                {
                    response.Message = successMessage ?? "Command executed successfully.";
                }
                else
                {
                    response.Message = failureMessage ?? "Command execution failed.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error executing command: {ex.Message}";
            }
            return response;
        }
    }
}
