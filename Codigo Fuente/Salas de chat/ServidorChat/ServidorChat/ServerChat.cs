using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ServidorChat
{
    private TcpListener servidor;
    private List<ClienteHandler> clientes = new List<ClienteHandler>();

    public ServidorChat(int puerto)
    {
        servidor = new TcpListener(IPAddress.Any, 1234); 
        servidor.Start();
        Console.WriteLine("Servidor iniciado. Esperando conexiones...");
        IniciarEsperaClientes();
    }

    public void IniciarEsperaClientes()
    {
        while (true)
        {
            TcpClient cliente = servidor.AcceptTcpClient();
            NetworkStream salaStream = cliente.GetStream();
            byte[] salaBuffer = new byte[1024];
            int salaBytesLeidos = salaStream.Read(salaBuffer, 0, salaBuffer.Length);
            if (salaBytesLeidos > 0)
            {
                string nombreSala = Encoding.ASCII.GetString(salaBuffer, 0, salaBytesLeidos);
                ClienteHandler clienteHandler = new ClienteHandler(cliente, this, nombreSala);
                clientes.Add(clienteHandler);
                Thread hiloCliente = new Thread(clienteHandler.Escuchar);
                hiloCliente.Start();
                Console.WriteLine("Nuevo cliente conectado desde: " + ((IPEndPoint)cliente.Client.RemoteEndPoint).Address.ToString());
            }
        }
    }

    public void EnviarMensajeATodos(string mensaje, ClienteHandler remitente)
    {
        foreach (var cliente in clientes)
        {
            if (cliente != remitente && cliente.SalaChat == remitente.SalaChat)
            {
                cliente.EnviarMensaje(mensaje);
            }
        }
    }

    static void Main()
    {
        int puerto = 1234;
        ServidorChat servidor = new ServidorChat(puerto);
    }
}

public class ClienteHandler
{
    private TcpClient cliente;
    private ServidorChat servidor;
    private NetworkStream stream;
    public string SalaChat { get; private set; }

    public ClienteHandler(TcpClient cliente, ServidorChat servidor, string nombreSala)
    {
        this.cliente = cliente;
        this.servidor = servidor;
        this.SalaChat = nombreSala;
        stream = cliente.GetStream();
    }

    public void Escuchar()
    {
        byte[] buffer = new byte[1024];
        int bytesLeidos;

        while (true)
        {
            try
            {
                bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                if (bytesLeidos > 0)
                {
                    string mensaje = Encoding.ASCII.GetString(buffer, 0, bytesLeidos);
                    servidor.EnviarMensajeATodos(mensaje, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de recepción: " + ex.Message);
                break;
            }
        }
    }

    public void EnviarMensaje(string mensaje)
    {
        byte[] datos = Encoding.ASCII.GetBytes(mensaje);
        stream.Write(datos, 0, datos.Length);
    }
}
