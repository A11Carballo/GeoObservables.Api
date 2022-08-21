using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GeoObservables.Api.DataAccess
{
    public class GeoObservablesDBContext : DbContext, IGeoObservablesDBContext
    {
        public GeoObservablesDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
