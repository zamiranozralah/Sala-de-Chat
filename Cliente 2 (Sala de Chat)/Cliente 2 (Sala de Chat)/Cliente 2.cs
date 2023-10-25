using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_2__Sala_de_Chat_
{
    class Cliente_2
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket Client;

        public Cliente_2(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            Client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Start()
        {
            Client.Connect(endPoint);
        }
        public void Send(string msg)
        {
            byte[] byteMsg = Encoding.Default.GetBytes(msg);
            Client.Send(byteMsg);
            Console.WriteLine("Mensaje enviado");
        }
    }
}
