using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL;
using DAL.Models;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class RentalRepository  : IRentalRepository
    {
        protected SdbContext DbCtx;
        public RentalRepository(SdbContext dbCtx)
        {
            DbCtx = dbCtx;
        }

        public async Task Save(Payload payload)
        {

            Rental rental = new Rental()
            {
                Car = new Car()
                {
                    Id = Guid.NewGuid(),
                    Category = Extension.ConvertFromIntToCarType(payload.CarCategory)
                },
                Id = Guid.NewGuid(),
                Customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = payload.DateOfBirth,
                },
                RentalDateTime = DateTime.Now,
                BookingNumber = Extension.GenerateBookingNumber()
            };

            
            await DbCtx.AddAsync(rental);
            await DbCtx.SaveChangesAsync();
            
        }

        public double Return(Payload payload)
        {
            try
            {
                var rental = DbCtx.Set<Rental>().Where(x => x.BookingNumber.Equals(payload.BookingNumber))
                    .Include(x=>x.Car)
                    .Include(x=>x.Customer).First();

                rental.Car.Milage += payload.NumberOfKm;
                rental.ReturnDateTime = payload.ReturnedDateTime;
                var rentalDays = (payload.ReturnedDateTime.Date - rental.RentalDateTime.Date).Days;
                rental.Price = Extension.CalculatePrice(rentalDays, payload.NumberOfKm, rental.Car.Category);

                DbCtx.SaveChanges();

                return rental.Price;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        IEnumerable<Rental> IRentalRepository.GetRentals()
        {
            return DbCtx.Set<Rental>();
        }
    }
}
