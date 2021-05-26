using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Rent.Car.Application.Queries;
using Rent.Car.Domain.Entities;
using Rent.Car.Domain.Interfaces;
using System.Collections.Generic;

namespace Rent.Car.APP.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GearTypeController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<GearType> Get()
        {
            var gearTypesRepository = HttpContext.RequestServices.GetRequiredService<IGearType>();

            return new GetGearType(gearTypesRepository).Handle();
        }
    }
}


