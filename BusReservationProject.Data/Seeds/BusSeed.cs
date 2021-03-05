using BusReservationProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Data.Seeds
{
    public class BusSeed : IEntityTypeConfiguration<Buses>
    {
        private readonly int[] _ids;
        public BusSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Buses> builder)
        {
            builder.HasData(new Buses
            {
                Id = _ids[0],
                Plate = "34AA123"
            }, new Buses
            {
                Id = _ids[1],
                Plate = "34BB123"
            }, new Buses
            {
                Id = _ids[2],
                Plate = "34CC123"
            });
        }
    }
}
