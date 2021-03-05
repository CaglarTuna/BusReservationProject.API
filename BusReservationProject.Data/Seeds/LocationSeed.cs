using BusReservationProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Data.Seeds
{
    public class LocationSeed : IEntityTypeConfiguration<Destinations>
    {
        private readonly int[] _ids;
        public LocationSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Destinations> builder)
        {

            builder.HasData(new Destinations
            {
                Id=_ids[0],
                Destination = "Sakarya"
            }, new Destinations
            {
                Id = _ids[1],
                Destination = "Düzce"
            }, new Destinations
            {
                Id = _ids[2],
                Destination = "Kocaeli"
            });
        }
    }
}
