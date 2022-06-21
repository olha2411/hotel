using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime EvictionDate { get; set; }

        public override string ToString()
        {
            return $"{ArrivalDate} - {EvictionDate}";
        }

    }
}
