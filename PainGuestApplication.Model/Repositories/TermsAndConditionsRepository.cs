using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class TermsAndConditionsRepository:BaseRepository<TermsAndConditions>
    {
        public TermsAndConditionsRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
