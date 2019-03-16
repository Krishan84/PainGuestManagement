using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class PainGuestRoomAllotment
    {
        public string ID { get; set; }
        public PainGuestRoomAllotment()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string B2BAccountRoomID { get; set; }
        public virtual B2BAccountRoom B2BAccountRoom { get; set; }
        public string PainGuestAgreementID { get; set; }
        public virtual PainGuestAgreement PainGuestAgreement { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfAllotment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
