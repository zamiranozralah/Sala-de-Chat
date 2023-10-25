using Cliente_2__Sala_de_Chat_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente__Sala_de_Chat_
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente_2 c = new Cliente_2("localhost", 1234);
            string msg;
            c.Start();
            while (true)
            {
                Console.WriteLine("Ingrese un mensaje: ");
                msg = Console.ReadLine();
                c.Send(msg);
            }
            Console.ReadKey();
        }
    }
}