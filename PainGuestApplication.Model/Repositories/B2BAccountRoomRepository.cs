using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class B2BAccountRoomRepository : BaseRepository<B2BAccountRoom>
    {
        public B2BAccountRoomRepository(UserIdentityDbContext context) : base(context)
        {

        }
    }

}
