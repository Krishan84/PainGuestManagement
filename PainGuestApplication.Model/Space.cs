using PainGuestApplication.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PainGuestApplication.Model
{
    public class Space
    {
        [Required]
        public SpaceType SpaceType { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Breadth { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        [Required]
        public bool IsCommercial { get; set; }
    }
}
