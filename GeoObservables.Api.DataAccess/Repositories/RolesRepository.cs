using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoObservables.Api.DataAccess.Repositories
{
    public class RolesRepository : Lazy<IRolesRepository>
    {
        private readonly Lazy<IGeoObservablesDBContext> _geoObservablesDBContext;

        public RolesRepository(Lazy<IGeoObservablesDBContext> geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<RolesEntity> Add(RolesEntity entity)
        {
            await _geoObservablesDBContext.Value.Roles.AddAsync(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return entity;
        }

        public async Task<RolesEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.Value.Roles.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.Value.Roles.Remove(Entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return Entity;
        }

        public async Task<bool> DeleteAsyncBool(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RolesEntity> Get(int idEntity) => await _geoObservablesDBContext.Value.Roles.FirstOrDefaultAsync(x => x.Id == idEntity);


        public async Task<IEnumerable<RolesEntity>> GetAll() => await _geoObservablesDBContext.Value.Set<RolesEntity>().ToListAsync();


        public async Task<RolesEntity> Update(int id, RolesEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Value.Roles.Update(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<RolesEntity> Update(RolesEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Value.Roles.Update(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return updateEntity.Entity;
        }
    }
}
