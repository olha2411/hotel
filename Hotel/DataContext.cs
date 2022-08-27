using System;
using System.Collections.Generic;
using System.Text;
using HotelStructure;
using HotelStructure.Models;
using HotelStructure.Models.Enums;


namespace Hotel
{
    public class DataContext
    {
        public List<Room> Rooms { get; set; } = new List<Room>
        {
            new Room
            {
                Id = 1,
                Number = 34,
                Capacity = 1,
                TypeId = 1,
            },

            new Room
            {
                Id = 2,
                Number = 36,
                Capacity = 2,
                TypeId = 2,
            },

            new Room
            {
                Id = 3,
                Number = 41,
                Capacity = 2,
                TypeId = 2,
            },

            new Room
            {
                Id = 4,
                Number = 42,
                Capacity = 2,
                TypeId = 1
            }
        };

        public List<Option> Options { get; set; } = new List<Option>
        {
            new Option
            {
                Id = 1,
                OptionName = "Conditioner"
            },

            new Option
            {
                Id = 2,
                OptionName = "Crib"
            },

            new Option
            {
                Id = 3,
                OptionName = "Refrigerator"
            },

        };

        public List<RoomOption> RoomOptions { get; set; } = new List<RoomOption>
        {
            new RoomOption
            {
                RoomId = 1,
                OptionId = 1,
            },

            new RoomOption
            {
                RoomId = 1,
                OptionId = 2,
            },

            new RoomOption
            {
                RoomId = 1,
                OptionId = 3,
            },

            new RoomOption
            {
                RoomId = 2,
                OptionId = 2,
            },

            new RoomOption
            {
                RoomId = 2,
                OptionId = 3,
            },

            new RoomOption
            {
                RoomId = 3,
                OptionId = 2,
            },

            new RoomOption
            {
                RoomId = 3,
                OptionId = 3,
            },


        };

        public List<RoomType> RoomTypes { get; set; } = new List<RoomType>
        {
            new RoomType
            {
                Id = 1,
                Type = "Standard"
            },

            new RoomType
            {
                Id = 2,
                Type = "Deluxe"
            },

            new RoomType
            {
                Id = 3,
                Type = "Joint"
            },

        };

        public List<Client> LocalClients { get; set; } = new List<Client>
        {
            new Client
            {
                Id = 1,
                Name = "Andriy",
                Surname = "Buhrovuch",
                Patronymic = "Valeriiovych",
                BirthDate = DateTime.Today.AddYears(-18),
                PhoneNumber = "0984517836",
            },

            new Client
            {
                Id = 2,
                Name = "Ameliya",
                Surname = "Polyuhovuch",
                Patronymic = "Viktorivna",
                BirthDate = DateTime.Today.AddYears(-30),
                PhoneNumber = "0984511336",
            },


            new Client
            {
                Id = 3,
                Name = "Nekras",
                Surname = "Kurbas",
                Patronymic = "Viktorovich",
                BirthDate = DateTime.Today.AddYears(-31),
                PhoneNumber = "0989511336",
            },
        };

        public List<Client> ForeignClients { get; set; } = new List<Client>
        {
            new Client
            {
                Id = 4,
                Name = "Adolphus",
                Surname = "Bush",
                BirthDate = DateTime.Today.AddYears(-28),
                PhoneNumber = "0984517836",
            },

            new Client
            {
                Id = 5,
                Name = "Nick",
                Surname = "Aberdeen",
                BirthDate = DateTime.Today.AddYears(-33),
                PhoneNumber = "0989511336",
            },
        };
        public List<Reservation> Reservations { get; set; } = new List<Reservation>
        {
            new Reservation
            {
                ClientId = 3,
                RoomId = 1,
                CheckInDate = DateTime.Today.AddDays(-3),
                CheckOutDate = DateTime.Today.AddDays(2),
            },

            new Reservation
            {
                ClientId = 2,
                RoomId = 3,
                CheckInDate = DateTime.Today.AddDays(-18),
                CheckOutDate = DateTime.Today.AddDays(-16),
            },

            new Reservation
            {
                ClientId = 2,
                RoomId = 2,
                CheckInDate = DateTime.Today.AddDays(-5),
                CheckOutDate = DateTime.Today.AddDays(-2),
            },

            new Reservation
            {
                ClientId = 3,
                RoomId = 4,
                CheckInDate = DateTime.Today.AddDays(-3),
                CheckOutDate = DateTime.Today.AddDays(1),
            },

            new Reservation
            {
                ClientId = 1,
                RoomId = 4,
                CheckInDate = DateTime.Today.AddDays(2),
                CheckOutDate = DateTime.Today.AddDays(5),
            },
        };

    }
}