using System;
using ListaDeExercicios18.Entities;

namespace ListaDeExercicios18.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        private ITaxService _taxService;
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;

        }
        public void ProcessInvoice(CarRental carRental)
        {
            double basicPayment = 0.0;
            TimeSpan date = carRental.Finish.Subtract(carRental.Start);
            if (date.TotalHours <= 12 ) 
            {
                basicPayment = PricePerHour * Math.Ceiling(date.TotalHours);
            } else
            {
                basicPayment = PricePerHour * Math.Ceiling(date.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
