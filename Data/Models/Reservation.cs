﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelStructure.Models
{
    public class Reservation
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int ClientId { get; set; }
        public int RoomId { get; set; }

        public override string ToString()
        {
            return $"{CheckInDate:d} - {CheckOutDate:d}";
        }

    }
}
