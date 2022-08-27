using System;
using System.Collections.Generic;
using System.Text;
using HotelStructure.Models.Enums;

namespace HotelStructure.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public int Capacity { get; set; }
        
        public int TypeId { get; set; }

        public override string ToString()
        {
            return $"Room {Number}, {Capacity} {(Capacity > 1 ? "people" : "person")}";
        }
    }
}
