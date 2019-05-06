using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
   public interface IDrazavaService
    {

        List<DrzavaDomenModel> GetDrzavas();
        DrzavaDomenModel GetDrzavaByID(int id);

        void AddDrzava(DrzavaDomenModel drzava);
        void UpdateDrzava(int id, DrzavaDomenModel drzava);
        void DeleteDrzava(int id);
    }
}
