﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
    public  interface IKlubService
    {



        List<KlubDomainModel> GetKlubs();
    }
}
