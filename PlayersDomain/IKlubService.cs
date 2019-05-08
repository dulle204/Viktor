using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
    public  interface IKlubService
    {

        List<KlubDomainModel> GetKlubs();
        KlubDomainModel GetKlubByID(int id);
        void AddKlub(KlubDomainModel klub);
        void UpdateKlub(int id, KlubDomainModel klub);
        void DeleteKlub(int id);
    }
}
