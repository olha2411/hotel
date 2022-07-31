using System;
using System.Collections.Generic;
using System.Linq;
using Hotel;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queries hotel = new Queries();

            Printer.PrintAllRooms(hotel.GetAllRooms());
            Printer.PrintAllReservations(hotel.GetAllReservations());
            Printer.PrintAllReservationsGroupedByClient(hotel.GetAllReservationsGroupedByClient());
            Printer.PrintAllRoomsWithTheirTypes(hotel.GetAllRoomsWithTheirTypes());
            Printer.PrintRoomsGroupedByType(hotel.GetRoomsGroupedByType());
            Printer.PrintClientsWithFewReservations(hotel.GetClientsWithFewReservations());
            Printer.PrintDeluxeRooms(hotel.GetDeluxeRooms());
            Printer.GetClientsWithReservationsCount(hotel.GetClientsWithReservationsCount());
            Printer.PrintRoomsWithReservations(hotel.GetRoomsWithReservations());
            Printer.PrintOccupiedRooms(hotel.GetOccupiedRooms());
            Printer.PrintAdultClients(hotel.GetAdultClients());
            Printer.PrintUnoccupiedRooms(hotel.GetUnoccupiedRooms());
            Printer.PrintClientsWithPatronymic(hotel.GetClientsWithPatronymic());            
            Printer.PrintRoomsWithRefrigerator(hotel.GetRoomsWithRefrigerator());
            Printer.PrintAllClients(hotel.GetAllClients());

            Console.ReadKey();
        }
    }
}
