using ListaDeExercicios18.Entities;
using ListaDeExercicios18.Services;
using System;
using System.Globalization;

namespace ListaDeExercicios18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rendal data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (DD/MM/YYYY HH:MM): ");
            DateTime start = DateTime.Parse(Console.ReadLine());
            Console.Write("Return (DD/MM/YYYY HH:MM): ");
            DateTime finish = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental car = new CarRental(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(car);

            Console.WriteLine($"INVOICE:\n{car.Invoice}");


        }
    }
}