using PainGuestApplication.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class Space
    {
        public SpaceType SpaceType { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public UnitType UnitType { get; set; }
        public bool IsCommercial { get; set; }
    }
}
