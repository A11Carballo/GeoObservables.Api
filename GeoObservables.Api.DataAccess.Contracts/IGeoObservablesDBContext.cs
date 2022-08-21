using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GeoObservables.Api.DataAccess.Contracts
{
    public interface IGeoObservablesDBContext
    {
        DbSet<UsersEntity> Users { get; set; }

        DbSet<RolesEntity> Roles { get; set; }

        DbSet<OriginEntity> Origin { get; set; }

        DbSet<HFlowdataEntity> HFlowdata { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void RemoveRange(IEnumerable<object> entities);

        EntityEntry Update(object entity);

        //Operaciones que realiza el contexto.
        //No hace falta definirlo en la clase de mi contexto por sobreescribe lo heredado de DBContext
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //void StatusLazy(bool status);
    }
}
