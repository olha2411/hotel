using System;
using System.Collections.Generic;

using Hotel;

namespace Lab1
{
     class Program
    {
        static void Main(string[] args)
        {
            Queries hotel = new Queries(new DataContext());

            Printer.PrintAllRooms(hotel.GetAllRooms());
            Printer.PrintAllClients(hotel.GetAllClients());
            Printer.PrintAllReservations(hotel.GetAllReservations());
            Printer.PrintAllReservationsGroupedByClient(hotel.GetAllReservationsGroupedByClient());
            Printer.PrintAllRoomsWithTheirTypes(hotel.GetAllRoomsWithTheirTypes());
            Printer.PrintRoomsGroupedByType(hotel.GetRoomsGroupedByType());
            Printer.PrintClientsWithFewReservations(hotel.GetClientsWithFewReservations(1));
            Printer.PrintDeluxeRooms(hotel.GetDeluxeRooms());
            Printer.GetClientsWithReservationsCount(hotel.GetClientsWithReservationsCount());
            Printer.PrintRoomsWithReservations(hotel.GetRoomsWithReservations());
            Printer.PrintOccupiedRooms(hotel.GetOccupiedRooms());
            Printer.PrintAdultClients(hotel.GetAdultClients(21));
            Printer.PrintUnoccupiedRooms(hotel.GetUnoccupiedRooms());
            Printer.PrintClientsWithPatronymic(hotel.GetClientsWithPatronymic());
            Printer.PrintRoomsWithRefrigerator(hotel.GetRoomsWithRefrigerator());

            Console.ReadKey();

        }
    }
}
