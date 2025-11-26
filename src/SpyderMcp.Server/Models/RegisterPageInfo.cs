using Spyder.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyderMcp.Server.Models
{
    public class RegisterPageInfo
    {
        public int PageIndex { get; set; }
        public string Name { get; set; } = string.Empty;

        public RegisterPageInfo()
        {
        }

        public RegisterPageInfo(RegisterPage fromPage)
        {
            this.PageIndex = fromPage.PageIndex;
            this.Name = fromPage.Name;
        }
    }
}
