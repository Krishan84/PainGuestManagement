using PainGuestApplication.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class PainGuestAgreement
    {
        public string ID { get; set; }
        public PainGuestAgreement()
        {
            ID = Guid.NewGuid().ToString();
        }
        [Required]
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }
        [Required]
        public string UserTermsAcceptanceID { get; set; }
        public virtual UserTermsAcceptance UserTermsAcceptance { get; set; }
        [Required]
        public string PainGuestID { get; set; }
        public virtual ApplicationUser PainGuest { get; set; }
        public string AdvanceRentTransactionID { get; set; }
        public virtual RentTransaction AdvanceRentTransaction { get; set; }
        [Required]
        public string CreatedOn { get; set; }
        [Required]
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
