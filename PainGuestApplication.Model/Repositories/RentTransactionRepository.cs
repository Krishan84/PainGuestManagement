using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class RentTransactionRepository:BaseRepository<RentTransaction>
    {
        public RentTransactionRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
