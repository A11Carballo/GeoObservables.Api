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
    public class HFlowdataEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<HFlowdataEntity> entityBuilder)
        {
            entityBuilder.ToTable("HFlowdata");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasOne(x => x.User).WithMany(x => x.HFlowdata).HasForeignKey(x => x.idUserCreate);

            entityBuilder.HasOne(x => x.Origin).WithMany(x => x.HFlowdata).HasForeignKey(x => x.idOrigin);
        }
    }
}
