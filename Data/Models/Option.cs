using System;
using System.Collections.Generic;
using System.Text;

namespace HotelStructure.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public override string ToString()
        {
            return OptionName;
        }
    }
}
