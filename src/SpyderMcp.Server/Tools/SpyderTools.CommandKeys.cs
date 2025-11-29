using ModelContextProtocol.Server;
using Spyder.Client.Common;
using SpyderMcp.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpyderMcp.Server.Tools
{
    public static partial class SpyderTools
    {
        [McpServerTool(Name = "spyder_recall_command_key")]
        [Description("Recalls a Command Key / Preset by register Id")]
        public static async Task<CommandResult> CommandKeyRecall(
            [Description("The Command Key register Id to recall")]
            int commandKeyId, 
            [Description("The Cue Id to use when recalling the Command Key. Any positive number is valid, but 0 is 'preview' and 1 is 'program'.  If not specifically provided, 1 is likely the correct value.")]
            int cueId)
        {
            return await RunSpyderCommandForMcp(
                server => server.RecallCommandKey(commandKeyId, cueId));
        }

        [McpServerTool(Name = "spyder_list_command_keys")]
        [Description("Lists all Command Keys / Presets on the connected Spyder server")]
        public static async Task<CommandResult<List<RegisterInfo>>> ListCommandKeys()
        {
            return await GetRegistersAsync(RegisterType.CommandKey);
        }

        [McpServerTool(Name = "spyder_list_command_key_pages")]
        [Description("Lists page info for all defined command key pages")]
        public static async Task<CommandResult<List<RegisterPageInfo>>> ListCommandKeyPages()
        {
            return await GetRegisterPagesAsync(RegisterType.CommandKey);
        }
    }
}
