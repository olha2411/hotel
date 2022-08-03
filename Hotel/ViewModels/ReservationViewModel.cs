using System;
using System.Collections.Generic;
using System.Text;
using HotelStructure.Models;

namespace Hotel.ViewModels
{
    public class ReservationViewModel
    {
        public Client Client { get; set; }
        public Room Room { get; set; }

        public Reservation Reservation { get; set; }

        public RoomType RoomType { get; set; }
    }
}
