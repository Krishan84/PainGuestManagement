using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class B2BAccountRepository:BaseRepository<B2BAccount>
    {
        public B2BAccountRepository(UserIdentityDbContext context) : base(context)
        {

        }
    }
}
