using System.Collections.Generic;

namespace PlayersDomain
{
    public interface IPlayerService
    {
        string Region { get; }

        List<IgracDomainModel> GetPlayers();
    }
}