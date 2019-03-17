using PainGuestApplication.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class RentTransaction
    {
        public string ID { get; set; }
        public RentTransaction()
        {
            ID = Guid.NewGuid().ToString();
        }
        [Required]
        public string PainGuestID { get; set; }
        public virtual ApplicationUser PainGuest { get; set; }
        [Required]
        public string B2BAccountRoomID { get; set; }
        public virtual B2BAccountRoom B2BAccountRoom { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public UnitType Unit { get; set; }
        [Required]
        public string TransactionReferenceNumber { get; set; }
        [Required]
        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
