using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string B2BAccountRoomID { get; set; }
        public virtual B2BAccountRoom B2BAccountRoom { get; set; }
        [Required]
        public string PainGuestAgreementID { get; set; }
        public virtual PainGuestAgreement PainGuestAgreement { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime DateOfAllotment { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
