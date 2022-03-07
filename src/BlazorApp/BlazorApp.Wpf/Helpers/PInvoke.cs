using System.Runtime.InteropServices;

namespace BlazorApp.Wpf.Helpers
{
    class PInvoke
    {
        [DllImport("wininet.dll")]
        internal static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);
    }

    [Flags]
    enum InternetGetConnectedState
    {
        Modem = 0x01,
        LAN = 0x02,
        Proxy = 0x04,
        RasInstalled = 0x10,
        Offline = 0x20,
        Configured = 0x40
    }
}
