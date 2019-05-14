using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Entity;

namespace BLL
{
    public interface IRentalRepository
    {
        Task Save(Payload payload);
        double Return(Payload payload);
        IEnumerable<Rental> GetRentals();
    }
}
