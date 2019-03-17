using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public class PainGuestRoomAllotmentRepository:BaseRepository<PainGuestRoomAllotment>
    {
        public PainGuestRoomAllotmentRepository(UserIdentityDbContext context):base(context)
        {

        }
    }
}
