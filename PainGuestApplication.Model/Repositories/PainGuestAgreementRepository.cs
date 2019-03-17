using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class PainGuestAgreementRepository:BaseRepository<PainGuestAgreement>
    {
        public PainGuestAgreementRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
