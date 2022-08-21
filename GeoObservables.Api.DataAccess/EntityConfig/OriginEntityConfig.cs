using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoObservables.Api.DataAccess.EntityConfig
{
    public class OriginEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<OriginEntity> entityBuilder)
        {
            entityBuilder.ToTable("Origin");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasMany(x => x.HFlowdata).WithOne(x => x.Origin);

        }
    }
}
