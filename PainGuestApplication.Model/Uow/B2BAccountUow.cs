using System;
using System.Collections.Generic;
using System.Text;
using PainGuestApplication.Model.Repositories;

namespace PainGuestApplication.Model.Uow
{
    public class B2BAccountUow : IB2BAccountUow, IDisposable
    {

        public B2BAccountUow()
        {
            CreateDbContext();
        }

        public IRepository<B2BAccount> B2BAccounts => throw new NotImplementedException();

        public IRepository<B2BAccountRoom> B2BAccountRooms => throw new NotImplementedException();

        public IRepository<PainGuestAgreement> PainGuestAgreements => throw new NotImplementedException();

        public IRepository<PainGuestRoomAllotment> PainGuestRoomAllotments => throw new NotImplementedException();

        public IRepository<TermsAndConditions> TermsAndConditions => throw new NotImplementedException();

        private UserIdentityDbContext DbContext { get; set; }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void CreateDbContext()
        {
            DbContext = new UserIdentityDbContext();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext!=null)
                {
                    DbContext.Dispose();
                }
            }
        }

    }
}
