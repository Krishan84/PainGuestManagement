using PainGuestApplication.Model.DTO;
using System;
using System.Collections.Generic;
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
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }

        public string UserTermsAcceptanceID { get; set; }
        public virtual UserTermsAcceptance UserTermsAcceptance { get; set; }
       
        public string PainGuestID { get; set; }
        public virtual ApplicationUser PainGuest { get; set; }
        public string AdvanceRentTransactionID { get; set; }
        public virtual RentTransaction AdvanceRentTransaction { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
