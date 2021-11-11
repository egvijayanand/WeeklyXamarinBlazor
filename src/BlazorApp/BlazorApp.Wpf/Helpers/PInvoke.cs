using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Wpf.Helpers
{
    public class PInvoke
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);
    }

    [Flags]
    public enum InternetGetConnectedState
    {
        Modem = 0x01,
        LAN = 0x02,
        Proxy = 0x04,
        RasInstalled = 0x10,
        Offline = 0x20,
        Configured = 0x40
    }
}
