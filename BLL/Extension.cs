using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace BLL
{
    public static class Extension
    {
        internal static Category ConvertFromIntToCarType(int i)
        {
            switch (i)
            {
                case 1:
                    return Category.SmallCar;
                case 2:
                    return Category.Van;
                case 3:
                    return Category.MiniBus;
                default:
                    return 0;
            }
        }

        internal static long GenerateBookingNumber()
        {
            Random random = new Random();
            return random.Next();
        }

        public static double CalculatePrice(int numberOfDays, double numberOfKm, Category category)
        {
            var baseDayRental = 50;
            var kmPrice = 10;

            if (numberOfDays == 0)
            {
                numberOfDays = 1;
            }

            switch (category)
            {
                case Category.SmallCar:
                    return baseDayRental * numberOfDays;
                case Category.Van:
                    return baseDayRental * numberOfDays * 1.2 + (kmPrice * numberOfKm);
                case Category.MiniBus:
                    return baseDayRental * numberOfDays * 1.7 + (kmPrice * numberOfKm * 1.5);
                default:
                    return 0;
            }
        }
    }
}
