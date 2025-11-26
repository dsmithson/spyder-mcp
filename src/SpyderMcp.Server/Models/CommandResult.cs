using System;
using System.Collections.Generic;
using System.Text;

namespace SpyderMcp.Server.Models
{
    public class CommandResult<T> : CommandResult
    {
        public T? Data { get; set; }
    }

    public class CommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
