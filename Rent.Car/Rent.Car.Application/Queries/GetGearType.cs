using Rent.Car.Domain.Entities;
using Rent.Car.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Car.Application.Queries
{
    public class GetGearType
    {
        private readonly IGearType gearTypes;

        public GetGearType(IGearType gearTypes)
        {
            this.gearTypes = gearTypes;
        }

        public List<GearType> Handle()
        {
            return gearTypes.GetAll();
        }
    }
}
