using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class ReviewRepository:BaseRepository<Review>
    {
        public ReviewRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
