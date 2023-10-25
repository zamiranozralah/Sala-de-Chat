using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor__Sala_de_chat_
{
    class Servidor
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket Server;
        Socket Client;
        public Servidor(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            Server = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(endPoint);
            Server.Listen(10);

        }

        public void Start()
        {
            Thread t;
            while (true)
            {
                Client = Server.Accept();
                Console.WriteLine("Esperando conexion...");
                t = new Thread(ClientConnetion);
                t.Start(Client);
                Console.WriteLine("Conectado");
                
            }

        }
        public void ClientConnetion(Object s)
        {
            Socket Client = (Socket)s;
            byte[] buffer;
            int endIndex;
            string message;
            while (true)
            {
                buffer = new byte[1024];
                Client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer);
                endIndex = message.IndexOf('\0');
                if (endIndex > 0)
                    message = message.Substring(0, endIndex);
                Console.WriteLine("Mensaje recibido: " + message);
                Console.Out.Flush();

            }
        }

    }
}
