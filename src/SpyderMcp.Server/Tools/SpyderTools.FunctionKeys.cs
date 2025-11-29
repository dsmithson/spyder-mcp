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
        [McpServerTool(Name = "spyder_recall_function_key")]
        [Description("Recalls a Function Key by register Id")]
        public static async Task<CommandResult> FunctionKeyRecall(
            [Description("The Function Key Id to recall")]
            int functionKeyId)
        {
            return await RunSpyderCommandForMcp(
                server => server.RecallFunctionKey(functionKeyId));
        }

        [McpServerTool(Name = "spyder_list_function_keys")]
        [Description("Lists all function keys")]
        public static async Task<CommandResult<List<RegisterInfo>>> ListFunctionKeys()
        {
            return await GetRegistersAsync(RegisterType.FunctionKey);
        }

        [McpServerTool(Name = "spyder_list_function_key_pages")]
        [Description("Lists page info for all defined function key pages")]
        public static async Task<CommandResult<List<RegisterPageInfo>>> ListFunctionKeyPages()
        {
            return await GetRegisterPagesAsync(RegisterType.FunctionKey);
        }
    }
}
