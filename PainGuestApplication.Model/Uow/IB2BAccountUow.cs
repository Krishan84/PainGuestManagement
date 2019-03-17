using PainGuestApplication.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Uow
{
    public interface IB2BAccountUow
    {
        void Commit();
        IRepository<B2BAccount> B2BAccounts { get; }
        IRepository<B2BAccountRoom> B2BAccountRooms { get; }
        IRepository<PainGuestAgreement> PainGuestAgreements { get; }
        IRepository<PainGuestRoomAllotment> PainGuestRoomAllotments { get; }
        IRepository<TermsAndConditions> TermsAndConditions { get; }
    }
}
