using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor__Sala_de_chat_
{
    class Program
    {
        static void Main(string[] args)
        {
            Servidor s = new Servidor("localhost", 1234);
            s.Start();

        }
    }
}