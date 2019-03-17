using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class B2BAccountRoom : Space
    {
        public string ID { get; set; }
        public B2BAccountRoom()
        {
            ID = Guid.NewGuid().ToString();
        }
        [Required]
        public bool IsVacant { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string UpdatedByUserID { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
        [Required]
        public bool IsKitchenAvailable { get; set; }
        [Required]
        public bool IsVerandaAvailable { get; set; }
        [Required]
        public int MonthlyAmount { get; set; }
        [Required]
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }
        public string PainGuestUserID { get; set; }
        public virtual ApplicationUser PainGuestUser { get; set; }
        [Required]
        public bool IsBedAvailable { get; set; }
        [Required]
        public bool IsFurnitureAvailable { get; set; }
        private ICollection<Review> _reviews { get; set; }
        public virtual ICollection<Review> Reviews
        {
            get { return _reviews ?? (_reviews = new List<Review>()); }
        }
    }
}
