using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class LanguageRepository:BaseRepository<Language>
    {
        public LanguageRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
