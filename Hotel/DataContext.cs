using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Models;
using Data.Models.Enums;


namespace Hotel
{
    public static class DataContext
    {
        public static List<HotelRoom> Rooms = new List<HotelRoom>()
        {
            new HotelRoom()
            {
                Id = 1,
                Number = 34,
                RoomByOccupancy = RoomByOccupancy.Double,
                RoomByLayout = RoomByLayout.Standard
            },

            new HotelRoom()
            {
                Id = 2,
                Number = 36,
                RoomByOccupancy = RoomByOccupancy.Double,
                RoomByLayout = RoomByLayout.Standard
            },

            new HotelRoom()
            {
                Id = 3,
                Number = 41,
                RoomByOccupancy = RoomByOccupancy.Double,
                RoomByLayout = RoomByLayout.Standard
            },

            new HotelRoom()
            {
                Id = 4,
                Number = 42,
                RoomByOccupancy = RoomByOccupancy.Double,
                RoomByLayout = RoomByLayout.Standard
            },


        };

        public static List<AdditionalOption> Options = new List<AdditionalOption>()
        {
           new AdditionalOption()
           {
                Id = 1,
                Option = "Air conditioning"
           },

           new AdditionalOption()
           {
                Id = 2,
                Option = "Crib"
           },
            
            new AdditionalOption()
            {
                Id = 2,
                Option = "Refrigerator"
            },

        };

        public static List<AdditionalOptionInRoom> OptionsInRooms = new List<AdditionalOptionInRoom>()
        {
            new AdditionalOptionInRoom()
            {
                RoomId = 1,
                OptionId = 1,
            },
            new AdditionalOptionInRoom()
            {
                RoomId = 2,
                OptionId = 2,
            },
            new AdditionalOptionInRoom()
            {
                RoomId = 1,
                OptionId = 3,
            },

            new AdditionalOptionInRoom()
            {
                RoomId = 4,
                OptionId = 3,
            },

            new AdditionalOptionInRoom()
            {
                RoomId = 4,
                OptionId = 1,
            },
        };

        public static List<Client> Clients = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                FirstName = "Andriy",
                SecondName = "Buhrovuch",
                Patroymic = "Valeriiovych",
                BirthDate = DateTime.Today.AddYears(-18),
                PhoneNumber = "0984517836",
            },

            new Client()
            {
                Id = 2,
                FirstName = "Ameliya",
                SecondName = "Polyuhovuch",
                Patroymic = "Viktorivna",
                BirthDate = DateTime.Today.AddYears(-30),
                PhoneNumber = "0984511336",
            },

            new Client()
            {
                Id = 3,
                FirstName = "Nick",
                SecondName = "Aberdeen",               
                BirthDate = DateTime.Today.AddYears(-33),
                PhoneNumber = "0989511336",
            },
        };

        public static List<Reservation> Reservations = new List<Reservation>()
        {
            new Reservation()
            {
                Id = 1,
                ClientId = 3,
                RoomId = 1,                
                ArrivalDate = DateTime.Today.AddDays(-3),
                EvictionDate = DateTime.Today.AddDays(2),
            },

            new Reservation()
            {
                Id = 2,
                ClientId = 3,
                RoomId = 6,
                ArrivalDate = DateTime.Today.AddDays(-18),
                EvictionDate = DateTime.Today.AddDays(-16),
            },

            new Reservation()
            {
                Id = 3,
                ClientId = 2,
                RoomId = 2,
                ArrivalDate = DateTime.Today.AddDays(-5),
                EvictionDate = DateTime.Today.AddDays(-2),
            },

            new Reservation()
            {
                Id = 4,
                ClientId = 3,
                RoomId = 4,
                ArrivalDate = DateTime.Today.AddDays(-4),
                EvictionDate = DateTime.Today.AddDays(2),
            },
        };

    } 
}

