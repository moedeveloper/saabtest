using DAL.Models;
using Xunit;
using static Xunit.Assert;

namespace BLL.Tests
{
    public class RentalTests
    {
        int numberOfDays = 1;
        double numberOfKm = 32;

        [Fact]
        public void CalculatePrice_SmallCar_Test()
        {

            var carType = Category.SmallCar;

            var price = Extension.CalculatePrice(numberOfDays, numberOfKm, carType);

            Equal(50, price);
        }

        
        [Fact]
        public void CalculatePrice_Van_Test()
        {

            var carType = Category.Van;

            var price = Extension.CalculatePrice(numberOfDays, numberOfKm, carType);

            Equal(380, price);
        }

        [Fact]
        public void CalculatePrice_MiniBuss_Test()
        {

            var carType = Category.MiniBus;

            var price = Extension.CalculatePrice(numberOfDays, numberOfKm, carType);

            Equal(565, price);
        }
    }
}
