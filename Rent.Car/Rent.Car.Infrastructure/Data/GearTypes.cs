using Rent.Car.Domain.Entities;
using Rent.Car.Domain.Interfaces;

namespace Rent.Car.Infrastructure.Data
{
    public class GearTypes : Repository<GearType>, IGearType
    {
        public GearTypes(RentCarContext ctx) : base(ctx)
        {
        }
    }
}
