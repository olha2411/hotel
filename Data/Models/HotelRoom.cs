using System;
using System.Collections.Generic;
using System.Text;
using Data.Models.Enums;

namespace Data.Models
{
    public class HotelRoom
    {
        public int Id { get; set; } 

        public int Number { get; set; }

        public RoomByOccupancy RoomByOccupancy { get; set; }

        public RoomByLayout RoomByLayout { get; set; }

        public override string ToString()
        {
            return $"{Number} - {RoomByOccupancy} - {RoomByLayout}";
        }
    }
}
