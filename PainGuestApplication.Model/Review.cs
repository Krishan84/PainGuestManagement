using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class Review
    {
        public string ID { get; set; }
        [Required]
        [StringLength(500)]
        public string ReviewComment { get; set; }
        [Required]
        public int ReviewerRating { get; set; }
        public string ReviewerID { get; set; }
        public virtual ApplicationUser Reviewer { get; set; }
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }
        public string RoomID { get; set; }
        public virtual B2BAccountRoom Room { get; set; }
    }
}
