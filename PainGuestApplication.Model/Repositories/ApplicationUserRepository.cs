using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class ApplicationUserRepository:BaseRepository<ApplicationUser>
    {
        public ApplicationUserRepository(UserIdentityDbContext context) : base(context)
        {

        }
    }
}
