using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace GeoObservables.Api.DataAccess
{
    public class GeoObservablesDBContext : DbContext, IGeoObservablesDBContext
    {
        public DbSet<UsersEntity> Users { get; set; }

        public DbSet<RolesEntity> Roles { get; set; }

        public DbSet<OriginEntity> Origin { get; set; }

        public DbSet<HFlowdataEntity> HFlowdata { get; set; }


        public GeoObservablesDBContext()
        {

        }

        public GeoObservablesDBContext(DbContextOptions<GeoObservablesDBContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UsersEntityConfig.SetEntityBuilder(modelBuilder.Entity<UsersEntity>());

            RolesEntityConfig.SetEntityBuilder(modelBuilder.Entity<RolesEntity>());

            OriginEntityConfig.SetEntityBuilder(modelBuilder.Entity<OriginEntity>());

            HFlowdataEntityConfig.SetEntityBuilder(modelBuilder.Entity<HFlowdataEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
