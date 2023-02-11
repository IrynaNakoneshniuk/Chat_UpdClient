using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Packaging;

namespace Chat_UpdClient
{
    public static class Upd_client
    {
        public static int localPort = 8001;
        public static  IPAddress brodcastAddress = IPAddress.Parse("224.0.0.0");
        public static string? username = null;
        public static string? msg = "Test";

        public static async Task SendMessageAsync(string ? message)
        {
            using var sender = new UdpClient();
            message = $"{username}: {message}";
            byte[] data = Encoding.Unicode.GetBytes(message);

            await sender.SendAsync(data, new IPEndPoint(brodcastAddress, localPort));
        }
        public static async Task<string> ReceiveMessageAsync()
        {
            using var receiver = new UdpClient(localPort); 
            receiver.JoinMulticastGroup(brodcastAddress);
            var result = await receiver.ReceiveAsync();
            string message = Encoding.Unicode.GetString(result.Buffer);
            return message;
        }
    }
}
