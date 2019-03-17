using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class UserTermsAcceptanceRepository:BaseRepository<UserTermsAcceptance>
    {
        public UserTermsAcceptanceRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
