using PlayersDomain.DomainModels;
using System.Collections.Generic;

namespace PlayersDomain
{
    public interface IPlayerService
    {
        string Region { get; }

        List<IgracDomainModel> GetPlayers();
        IgracDomainModel GetPlayersByID(int id);
        void AddPlayer(AddPlayerModel igrac);
        void UpdatePlayer(int id, AddPlayerModel igrac);
    }
}