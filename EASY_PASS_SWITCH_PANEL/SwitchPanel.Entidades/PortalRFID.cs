using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASY_PASS_SWITCH_PANEL.SwitchPanel.Entidades
{
    public class PortalRFID
    {
        public int PortalID { get; set; }
        public string PortalName { get; set; }
        public string ReaderHostName { get; set; }
        public string ReaderSerie { get; set; }
        public string ReaderIP { get; set; }
        public int ReaderModel { get; set; }
        public byte[] ReaderImage { get; set; }
        public bool ReaderSatus { get; set; }
        public string Email { get; set; }
        public bool EmailStatus { get; set; }
        public string EmailCC { get; set; }
        public bool ReaderVisible { get; set; }
    }
}
