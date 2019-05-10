using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
   public interface ILigaService
    {
        List<LigaDomianModel> GetLiga();
        LigaDomianModel GetLigaID(int id);
        void AddLiga(LigaDomianModel liga);
        void UpdateLiga(int id, LigaDomianModel liga);
        void DeleteLiga(int id);
    }
}
