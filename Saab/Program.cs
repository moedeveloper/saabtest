using System;
using BLL;
using DAL;
using Entity;

namespace Saab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use DI instead
            IRentalRepository _rental = new RentalRepository(new SdbContext());

            Console.WriteLine("Enter * to rent a Car or ** To return");
            var input = Console.ReadLine();

            if (input == "*")
            {
                Console.WriteLine("Enter Data of Birth");
                var birthDate = Console.ReadLine();
                Console.WriteLine("Enter Type of Car");
                Console.WriteLine("1- Small Car");
                Console.WriteLine("2- Van");
                Console.WriteLine("3- Mini Bus");

                var carType = Convert.ToInt32(Console.ReadLine());

                var payload = new Payload()
                {
                    CarCategory =  carType, 
                    DateOfBirth = birthDate
                };

                _rental.Save(payload).Wait();
            }

            if (input == "**")
            {
                Console.WriteLine("Enter Number of Km: ");
                var milage = Convert.ToDouble(Console.ReadLine());

               

                var rentals = _rental.GetRentals();
                foreach (var rt in rentals)
                {
                    Console.WriteLine($"Available Booking Number {rt.BookingNumber}");
                }
                Console.WriteLine("Enter Booking Number: ");
                var bkNumber = Convert.ToUInt32(Console.ReadLine());

                var payload = new Payload()
                {
                    NumberOfKm = milage,
                    ReturnedDateTime = DateTime.Now,
                    BookingNumber = bkNumber,
                };
                var price = _rental.Return(payload);

                Console.WriteLine($"Total to pay: {price} Kr" );
            }

            Console.ReadLine();
        }
    }
}
