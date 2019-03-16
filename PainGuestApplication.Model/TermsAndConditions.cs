using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class TermsAndConditions
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string VersionNumber { get; set; }
        public bool Active { get; set; }
        public DocumentType DocumentType { get; set; }
    }
    public enum DocumentType
    {
        TermsAndConditions,
        PrivacyPolicy,
        RoomTermsAndConditions
    }
}
