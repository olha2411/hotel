using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Hotel.ViewModels;
using Data.Models.Enums;


namespace Hotel
{
    public class Queries
    {
        // 1. All Rooms
        
        public IEnumerable<Room> GetAllRooms()
        {
            return from room in DataContext.Rooms
                   select room;
        }

        // 2. All Reservations With Clients And Rooms Info

        public IEnumerable<ReservationViewModel> GetAllReservations()
        {
            return    from reservation in DataContext.Reservations
                      join client in DataContext.Clients on reservation.ClientId equals client.Id
                      join room in DataContext.Rooms on reservation.RoomId equals room.Id
                      join type in DataContext.RoomTypes on room.TypeId equals type.Id                  
                      select new ReservationViewModel
                      {
                            Client = client,
                            Room = room,
                            Reservation = reservation,
                            RoomType = type
                      };
        }

        // 3. All Reservations With Room Info Grouped By Client, Sorted By Client Surname And CheckIn Date 
        
        public Dictionary<Client, IEnumerable<ReservationViewModel>> GetAllReservationsGroupedByClient()
        {
            var query = from reservation in DataContext.Reservations
                       join client in DataContext.Clients on reservation.ClientId equals client.Id
                       join room in DataContext.Rooms on reservation.RoomId equals room.Id
                       join type in DataContext.RoomTypes on room.TypeId equals type.Id
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

            return query.ToDictionary(m => m.Key, n => n.Select(room => room));
        }
        
        
        // 4. Rooms With Their Types
        public IEnumerable<RoomTypeViewModel> GetAllRoomsWithTheirTypes()
        {
            return DataContext.Rooms.Join(DataContext.RoomTypes,
                   r => r.TypeId,
                   t => t.Id,
                   (r, t) => new RoomTypeViewModel
                   {
                       Room = r,
                       RoomType = t
                   });
        }

        // 5. Rooms Grouped By Type
               
        public Dictionary<int, IEnumerable<Room>> GetRoomsGroupedByType()
        {
            var result = DataContext.Rooms.Join(DataContext.RoomTypes,
                      r => r.TypeId,
                      t => t.Id,
                      (r, rooms) => new
                      {
                          Room = r,
                          Rooms = rooms,

                      }).GroupBy(q => q.Room.TypeId);

            return result.ToDictionary(m => m.Key, n => n.Select(room => room.Room));

        }
        
        // 6. Clients With More Than 1 Reservation
        public IEnumerable<Client> GetClientsWithFewReservations()
            {
                return from client in DataContext.Clients
                       join reservation in DataContext.Reservations on client.Id equals reservation.ClientId
                       group reservation by client into g
                       where g.Count() > 1
                       select g.Key;
            }

        // 7. Deluxe Rooms
        public IEnumerable<Room> GetDeluxeRooms()
        {
            return from room in DataContext.Rooms
                   join type in DataContext.RoomTypes on room.TypeId equals type.Id
                   where type.Type.Equals("Deluxe", StringComparison.OrdinalIgnoreCase)
                   select room;
        }

        // 8. Clients With Reservations Count
                
        public Dictionary<Client, int> GetClientsWithReservationsCount()
        {
            var query = DataContext.Clients.GroupJoin(DataContext.Reservations,
                        c => c.Id,
                        r => r.ClientId,
                        (c, reservations) => new
                        {
                            Client = c,
                            Reserv = reservations
                        }).OrderByDescending(m => m.Reserv.Count());

            return query.ToDictionary(g => g.Client, g => g.Reserv.Count());

        }


       

        // 9. Rooms With Reservations, Sorted By CheckIn Date
        public Dictionary<RoomTypeViewModel, IEnumerable<Reservation>> GetRoomsWithReservations()
        {
            var query =  from room in DataContext.Rooms
                         join type in DataContext.RoomTypes on room.TypeId equals type.Id
                         join reservation in DataContext.Reservations on room.Id equals reservation.RoomId
                         orderby reservation.CheckInDate
                         group reservation by new RoomTypeViewModel()
                         { 
                             Room = room,
                             RoomType = type,
                         } 
                         into g
                         select g;

            return query.ToDictionary(g => g.Key, g => g.Select(r => r));

          
        }

        // 10. Currently Occupied Rooms
        
        public IEnumerable<RoomTypeViewModel> GetOccupiedRooms()
        {
            return from room in DataContext.Rooms
                   join type in DataContext.RoomTypes on room.TypeId equals type.Id
                   join reservation in DataContext.Reservations on room.Id equals reservation.RoomId
                   where reservation.CheckInDate <= DateTime.Today && DateTime.Today <= reservation.CheckOutDate
                   select new RoomTypeViewModel
                   {
                       Room = room,
                       RoomType = type

                   };
        }

        // 11. Client Who Are More Than 21
        public IEnumerable<Client> GetAdultClients()
        {
            return DataContext.Clients.Where(client => client.BirthDate.AddYears(21) < DateTime.Today);
        }
        
        // 12. Currently Unoccupied Rooms
        public IEnumerable<RoomTypeViewModel> GetUnoccupiedRooms()
        {
            return GetAllRoomsWithTheirTypes().Select(rt => rt.Room)
                   .Except(GetOccupiedRooms().Select(rt => rt.Room))
                   .Join(DataContext.RoomTypes,
                         r => r.TypeId, t => t.Id,
                         (r, t) => new RoomTypeViewModel()
                         {
                             Room = r,
                             RoomType = t

                         });                   
        }
        // 13. Clients With Patronymic
        public IEnumerable<Client> GetClientsWithPatronymic()
        {
            return DataContext.Clients.Where(client => !string.IsNullOrEmpty(client.Patronymic));
        }
              

        // 14. Rooms With Refrigerator
        public IEnumerable<RoomTypeViewModel> GetRoomsWithRefrigerator()
        {
            return from room in DataContext.Rooms
                   join type in DataContext.RoomTypes on room.TypeId equals type.Id
                   where room.Options.Contains(Options.Refrigerator)
                   select new RoomTypeViewModel
                   {
                       Room = room,
                       RoomType = type

                   };
        }
        //15. Get All Clients
        public IEnumerable<Client> GetAllClients()
        {
            return DataContext.Clients.Concat(DataContext.ForeignClients);
        }
    }
}

