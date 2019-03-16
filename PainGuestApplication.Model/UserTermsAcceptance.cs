using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class UserTermsAcceptance
    {
        public string ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string TermsAndConditionsID { get; set; }
        public virtual TermsAndConditions TermsAndConditions { get; set; }
        public DocumentType DocumentType { get; set; }

        public string AgreementID { get; set; }
    }
}
