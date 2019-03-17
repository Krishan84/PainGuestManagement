using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(255)]
        public string GuestHouseName { get; set; }
        [Required]
        public string PrimaryContactUserID { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Fax { get; set; }
        [Required]
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool LoginEnabled { get; set; }
        [Required]
        public string LanguageID { get; set; }
        public virtual Language Language { get; set; }
        
        public string HrManagerUserID { get; set; }
        public virtual ApplicationUser HrManagerUser { get; set; }
        public string BrokerUserID { get; set; }
        public virtual ApplicationUser BrokerUser { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
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
