using System.Collections.Generic;

namespace PlayersDatav1.Repositories
{
    public interface ILigaRepository : IGenericRepository<Liga>
    {
        List<Liga> GetLigaByDrzava(int id);
        List<Liga> GetLigaByDrzava(string name);
    }
}