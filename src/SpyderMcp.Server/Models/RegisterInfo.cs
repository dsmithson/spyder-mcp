using Spyder.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyderMcp.Server.Models
{
    public class RegisterInfo
    {
        public int Id { get; set; }
        public int PageIndex { get; set; }
        public string Name { get; set; } = string.Empty;

        public RegisterInfo()
        {

        }

        public RegisterInfo(IRegister fromRegister)
        {
            this.Id = fromRegister.RegisterID;
            this.Name = fromRegister.Name;
            this.PageIndex = fromRegister.PageIndex;
        }
    }
}
