using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class BankAccountInformation
    {
        public BankAccountInformation()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        [Required]
        [StringLength(255)]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string RoutingNumber { get; set; }
        [Required]
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string B2BAccountID { get; set; }
        public virtual B2BAccount B2BAccount { get; set; }
    }
}
