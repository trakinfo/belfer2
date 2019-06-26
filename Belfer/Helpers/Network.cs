using System.Net;
using System.Net.Sockets;

namespace Belfer.Helpers
{
    public static class Network
    {
        public static string HostName()
        {
            return Dns.GetHostName();
        }
        public static string HostIPv4()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

    }
}
