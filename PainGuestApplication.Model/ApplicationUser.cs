using Microsoft.AspNetCore.Identity;
using PainGuestApplication.Model.DTO;
using PainGuestApplication.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PainGuestApplication.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return string.Format("{0}{1}{2}", (!string.IsNullOrEmpty(FirstName) ? FirstName + " " : ""), (!string.IsNullOrEmpty(MiddleInitial) ? MiddleInitial + " " : ""), LastName ?? "").Trim();
            }
        }
        [Required]
        public string AadharNumber { get; set; }
        public string AlternateEmail { get; set; }
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
        [StringLength(10)]
        public DateTime DOB { get; set; }
        public int? Age => UtilityMethods.CalculateAge(DOB, DateTime.UtcNow);

        public DateTime? TerminationDate { get; set; }
        public DateTime? TermsAndConditionsAcceptedOn { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public GenderType? Gender { get; set; }
        public string GenderDescription { get; set; }
        [Required]
        public RegistrationStatus RegistrationStatus { get; set; }
        [Required]
        public UserType Usertype { get; set; }
        public string LanguageID { get; set; }
        public virtual Language Language { get; set; }
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool Disablity { get; set; }
        [Required]
        public Status Status { get; set; }
        public bool Active { get; set; }
        [Required]
        public string B2CObjectId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string UpdatedByUserID { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }

        private ICollection<Review> _reviewsGiven { get; set; }
        public virtual ICollection<Review> ReviewsGiven
        {
            get { return _reviewsGiven ?? (_reviewsGiven = new List<Review>()); }
        }
        private ICollection<BankAccountInformation> _bankInformations { get; set; }
        public virtual ICollection<BankAccountInformation> BankInformations
        {
            get { return _bankInformations ?? (_bankInformations = new List<BankAccountInformation>()); }
        }
    }
}
