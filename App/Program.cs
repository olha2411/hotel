using System;
using Hotel;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queries hotel = new Queries();

            Viewer.ShowAllClients(hotel.GetAllClients());
            Viewer.ShowAllClientsReservation(hotel.GetClientsReservation());
        }
    }
}
