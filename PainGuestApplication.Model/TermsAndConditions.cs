using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class TermsAndConditions
    {
        public string ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string VersionNumber { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
    }
    public enum DocumentType
    {
        TermsAndConditions,
        PrivacyPolicy,
        RoomTermsAndConditions
    }
}
