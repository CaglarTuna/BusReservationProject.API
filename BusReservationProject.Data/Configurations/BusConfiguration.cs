using BusReservationProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Data.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Buses>
    {
        public void Configure(EntityTypeBuilder<Buses> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
