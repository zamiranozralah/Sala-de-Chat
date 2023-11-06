using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClienteChat
{
    public class cliente
    {

        private TcpClient clienteChat;
        private NetworkStream stream;
        private string nombreUsuario;
        private RichTextBox richTextBoxMensajes;
        private Color colorMensajesRecibidos = Color.Green;

        public cliente(string servidorIP, int puerto, string nombreUsuario, RichTextBox richTextBoxMensajes, string nombreSala)
        {
            this.nombreUsuario = nombreUsuario;
            this.richTextBoxMensajes = richTextBoxMensajes;
            clienteChat = new TcpClient(servidorIP, puerto);
            stream = clienteChat.GetStream();
            EnviarNombreSala(nombreSala);
            // Hilo de recepción
            Thread hiloRecepcion = new Thread(RecibirMensajes);
            hiloRecepcion.Start();
        }
        public void EnviarNombreSala(string nombreSala)
        {
            byte[] salaData = Encoding.ASCII.GetBytes(nombreSala);
            stream.Write(salaData, 0, salaData.Length);
        }
        public void EnviarMensaje(string mensaje)
        {
            string mensajeFormateado = mensaje;
            richTextBoxMensajes.SelectionColor = Color.White;
            richTextBoxMensajes.AppendText(mensajeFormateado + Environment.NewLine);
            richTextBoxMensajes.SelectionColor = richTextBoxMensajes.ForeColor; // Restaura el color de fuente predeterminado

            byte[] datos = Encoding.ASCII.GetBytes(mensajeFormateado);
            stream.Write(datos, 0, datos.Length);
        }

        public void RecibirMensajes()
        {
            byte[] buffer = new byte[1024];
            int bytesLeídos;

            while (true)
            {
                try
                {
                    bytesLeídos = stream.Read(buffer, 0, buffer.Length);
                    if (bytesLeídos > 0)
                    {
                        string mensaje = Encoding.ASCII.GetString(buffer, 0, bytesLeídos);

                        // Agregar el mensaje recibido al RichTextBox con formato verde.
                        richTextBoxMensajes.Invoke((MethodInvoker)(() => {
                            richTextBoxMensajes.SelectionColor = colorMensajesRecibidos;
                            richTextBoxMensajes.AppendText(mensaje + Environment.NewLine);
                            richTextBoxMensajes.SelectionColor = richTextBoxMensajes.ForeColor; // Restaura el color de fuente predeterminado
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de recepción: " + ex.Message);
                    break;
                }
            }
        }
    }
}
