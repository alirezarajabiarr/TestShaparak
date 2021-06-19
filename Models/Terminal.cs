using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class Terminal
    {
        public long sequence { get; set; }
        public string terminalNumber { get; set; }
        public TerminalTypeEnum terminalType { get; set; }
        public string serialNumber { get; set; }
        public long? setupDate { get; set; }
        public string hardwareBrand { get; set; }
        public string hardwareModel { get; set; }
        public string accessAddress { get; set; }
        public long? accessPort { get; set; }
        public string callbackAddress { get; set; }
        public long? callbackPort { get; set; }
        //public string Description { get; set; }
        public UpdateActionEnum updateAction { get; set; }












    }
}
