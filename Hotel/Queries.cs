using System;
using System.Collections.Generic;
using System.Linq;
using HotelStructure;
using HotelStructure.Models;
using Hotel.ViewModels;
using HotelStructure.Models.Enums;


namespace Hotel
{
    public class Queries
    {
        private readonly DataContext _dataContext;

        public Queries(DataContext dataContext)
        {

            _dataContext = dataContext;
        }
        // 1. All Rooms        
        public IEnumerable<Room> GetAllRooms()
        {
            return from room in _dataContext.Rooms
                   select room;
        }

        //2. Get All Clients
        public IEnumerable<Client> GetAllClients()
        {
            return _dataContext.LocalClients.Concat(_dataContext.ForeignClients);
        }

        // 3. All Reservations With Clients And Rooms Info
        public IEnumerable<ReservationViewModel> GetAllReservations()
        {
            return from reservation in _dataContext.Reservations
                   join client in GetAllClients() on reservation.ClientId equals client.Id
                   join room in _dataContext.Rooms on reservation.RoomId equals room.Id
                   join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                   select new ReservationViewModel
                   {
                       Client = client,
                       Room = room,
                       Reservation = reservation,
                       RoomType = type
                   };
        }

        // 4. All Reservations With Room Info Grouped By Client, Sorted By Client Surname And CheckIn Date 
        public Dictionary<Client, IEnumerable<ReservationViewModel>> GetAllReservationsGroupedByClient()
        {
            var query = from reservation in _dataContext.Reservations
                        join client in GetAllClients() on reservation.ClientId equals client.Id
                        join room in _dataContext.Rooms on reservation.RoomId equals room.Id
                        join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                        orderby client.Surname, reservation.CheckInDate
                        group new ReservationViewModel()
                        {
                            Client = client,
                            Room = room,
                            Reservation = reservation,
                            RoomType = type
                        }
                        by client into g
                        select g;

            Func<string, int> func = s => s.Length;
            var q1 = func;
            func.Invoke("tiolkdd");


            return query.ToDictionary(m => m.Key, n => n.Select(room => room));
        }

        // 5. Rooms With Their Types
        public IEnumerable<RoomTypeViewModel> GetAllRoomsWithTheirTypes()
        {
            return _dataContext.Rooms.Join(_dataContext.RoomTypes,
                   r => r.TypeId,
                   t => t.Id,
                   (r, t) => new RoomTypeViewModel
                   {
                       Room = r,
                       RoomType = t
                   });
        }

        // 6. Rooms Grouped By Type 

        public Dictionary<string, IEnumerable<Room>> GetRoomsGroupedByType()
        {
            var result = _dataContext.Rooms.Join(_dataContext.RoomTypes,
                      r => r.TypeId,
                      t => t.Id,
                      (r, type) => new RoomTypeViewModel
                      {
                          Room = r,
                          RoomType = type,

                      }).GroupBy(q => q.RoomType.Type);

            return result.ToDictionary(m => m.Key, n => n.Select(room => room.Room));

        }

        // 7. Clients With More Than 1 Reservation
        public IEnumerable<Client> GetClientsWithFewReservations(int count)
        {
            return from client in GetAllClients()
                   join reservation in _dataContext.Reservations on client.Id equals reservation.ClientId
                   group reservation by client into g
                   where g.Count() > count
                   select g.Key;
        }

        // 8. Deluxe Rooms
        public IEnumerable<Room> GetDeluxeRooms()
        {
            return from room in _dataContext.Rooms
                   join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                   where type.Type.Equals("Deluxe", StringComparison.OrdinalIgnoreCase)
                   select room;
        }

        // 9. Clients With Reservations Count

        public Dictionary<Client, int> GetClientsWithReservationsCount()
        {
            var query = GetAllClients().GroupJoin(_dataContext.Reservations,
                        c => c.Id,
                        r => r.ClientId,
                        (c, reservations) => new
                        {
                            Client = c,
                            Reserv = reservations
                        }).OrderByDescending(m => m.Reserv.Count());

            return query.ToDictionary(g => g.Client, g => g.Reserv.Count());

        }

        // 10. Rooms With Reservations, Sorted By CheckIn Date
        public Dictionary<RoomTypeViewModel, IEnumerable<Reservation>> GetRoomsWithReservations()
        {
            var query = from room in _dataContext.Rooms
                        join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                        join reservation in _dataContext.Reservations on room.Id equals reservation.RoomId
                        orderby reservation.CheckInDate
                        group reservation by new RoomTypeViewModel()
                        {
                            Room = room,
                            RoomType = type,
                        };

            return query.ToDictionary(g => g.Key, g => g.Select(r => r));

        }

        // 11. Currently Occupied Rooms

        public IEnumerable<RoomTypeViewModel> GetOccupiedRooms()
        {
            return from room in _dataContext.Rooms
                   join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                   join reservation in _dataContext.Reservations on room.Id equals reservation.RoomId
                   where reservation.CheckInDate <= DateTime.Today && DateTime.Today <= reservation.CheckOutDate
                   select new RoomTypeViewModel
                   {
                       Room = room,
                       RoomType = type

                   };
        }

        // 12. Client Who Are More Than "age"
        //check years 
        public IEnumerable<Client> GetAdultClients(int age)
        {
            return GetAllClients().Where(client => client.BirthDate.AddYears(age) < DateTime.Today);
        }


        // 13. Currently Unoccupied Rooms
        public IEnumerable<RoomTypeViewModel> GetUnoccupiedRooms()
        {
            var query = GetAllRoomsWithTheirTypes().Select(rt => rt.Room)
                   .Except(GetOccupiedRooms().Select(rt => rt.Room))
                   .Join(_dataContext.RoomTypes,
                         r => r.TypeId, t => t.Id,
                         (r, t) => new RoomTypeViewModel()
                         {
                             Room = r,
                             RoomType = t

                         });
            return query;
        }
        // 14. Clients With Patronymic
        public IEnumerable<Client> GetClientsWithPatronymic()
        {
            return GetAllClients().Where(client => !string.IsNullOrEmpty(client.Patronymic));
        }

        // 15. Rooms With Refrigerator
       
        public IEnumerable<RoomTypeViewModel> GetRoomsWithRefrigerator()
        {
            return from room in _dataContext.Rooms
                   join type in _dataContext.RoomTypes on room.TypeId equals type.Id
                   join roomOption in _dataContext.RoomOptions on room.Id equals roomOption.RoomId
                   join option in _dataContext.Options on roomOption.OptionId equals option.Id
                   where option.OptionName.Equals("Refrigerator", StringComparison.OrdinalIgnoreCase)
                   select new RoomTypeViewModel
                   {
                       Room = room,
                       RoomType = type

                   };
        }

    }
}
