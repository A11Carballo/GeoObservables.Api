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
    public class UsersEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UsersEntity> entityBuilder)
        {
            entityBuilder.ToTable("Users");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasOne(x => x.Roles).WithMany(x => x.Users).HasForeignKey(x => x.IdRole);

            entityBuilder.HasMany(x => x.HFlowdata).WithOne(x => x.User);
        }
    }
}
