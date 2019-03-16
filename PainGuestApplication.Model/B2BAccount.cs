using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class B2BAccount
    {
        public B2BAccount()
        {
            ID = Guid.NewGuid().ToString().ToUpper();
        }
        public string ID { get; set; }
        public string GuestHouseName { get; set; }
        public string PrimaryContactUserID { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public bool LoginEnabled { get; set; }
        public string LanguageID { get; set; }
        public virtual Language Language { get; set; }
        public string HrManagerUserID { get; set; }
        public virtual ApplicationUser HrManagerUser { get; set; }
        public string BrokerUserID { get; set; }
        public virtual ApplicationUser BrokerUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedByUserID { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
        private ICollection<ApplicationUser> _users { get; set; }
        public virtual ICollection<ApplicationUser> Users
        {
            get { return _users ?? (_users = new List<ApplicationUser>()); }
        }
        private ICollection<Review> _reviews { get; set; }
        public virtual ICollection<Review> Reviews
        {
            get { return _reviews ?? (_reviews = new List<Review>()); }
        }
        private ICollection<BankAccountInformation> _bankInformations { get; set; }
        public virtual ICollection<BankAccountInformation> BankInformations
        {
            get { return _bankInformations ?? (_bankInformations = new List<BankAccountInformation>()); }
        }
    }
}
