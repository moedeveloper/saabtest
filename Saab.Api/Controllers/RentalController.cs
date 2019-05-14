using System;
using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Saab.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepo;

        public RentalController(IRentalRepository repo)
        {
            _rentalRepo = repo;
        }

        [HttpPost]
        [Route("price")]
        public ActionResult<double> GetPrice(Payload payload)
        {
            payload.ReturnedDateTime = DateTime.Now;
            return _rentalRepo.Return(payload);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] Payload payload)
        {
            _rentalRepo.Save(payload);

            return new ActionResult<string>("Done");
        }
    }
}
