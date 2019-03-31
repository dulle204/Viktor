using PlayersData2;
using System.Collections.Generic;

namespace Players.ConsoleApp
{
    internal interface IIgraci
    {
        string Region { get; }

        List<Igrac> Get();
    }
}