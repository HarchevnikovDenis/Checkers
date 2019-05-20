using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCheckers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ЧЕШСКИЕ Шашки для двоих";
            Console.SetWindowSize(70, 30);
            //Console.OutputEncoding = Encoding.GetEncoding(866);
            Field GameField = new Field();
        }
    }
}
