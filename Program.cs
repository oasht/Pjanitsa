using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DruncKard
{

    internal class Program
    {

        static void Main(string[] args)
        {
            
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            Cards stack = new Cards();
            stack.Distribution();
            stack.Game();


        }
    }
}