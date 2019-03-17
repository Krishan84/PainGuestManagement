using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class Language
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(255)]
        public string DisplayName { get; set; }
        public string Locale { get; set; }
        [Required]
        public bool Active { get; set; }
        private ICollection<ApplicationUser> _users { get; set; }
        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return _users ?? (_users = new List<ApplicationUser>());
            }
            protected set
            {
                _users = value;
            }
        }
    }
}
