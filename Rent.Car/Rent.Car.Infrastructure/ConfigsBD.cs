using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Car.Domain.Entities;

namespace Rent.Car.Infrastructure
{
    public static class ConfigsBD
    {
        public static void  ConfigBD(ModelBuilder builder)
        {
            ConfigGearTypes(builder);
        }


        private static void ConfigGearTypes(ModelBuilder builder)
        {
            builder.Entity<GearType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).HasMaxLength(50).IsRequired();
            });
        }
    }
}
