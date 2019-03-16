using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class AccessLog
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
        public string AdminId { get; set; }
        public string Browser { get; set; }
        public string ReturnUrl { get; set; }
        public LoginType LoginType { get; set; }
    }
    public enum LoginType
    {
        Regular
    }
}
