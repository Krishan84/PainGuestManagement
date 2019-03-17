using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class BankAccountInformationRepository:BaseRepository<BankAccountInformation>
    {
        public BankAccountInformationRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
