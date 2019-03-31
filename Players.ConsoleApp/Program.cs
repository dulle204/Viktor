using PlayersData2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            var igraci = factory.GetInstance("EU");

            var data = igraci.Get();
            Console.WriteLine(data.FirstOrDefault().Tezina);

            Console.ReadKey();
        }
    }
}
