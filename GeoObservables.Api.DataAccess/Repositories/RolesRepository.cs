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
    public class RolesRepository : IRolesRepository
    {
        private readonly GeoObservablesDBContext _geoObservablesDBContext;

        public RolesRepository(GeoObservablesDBContext geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<RolesEntity> Add(RolesEntity entity)
        {
            await _geoObservablesDBContext.Roles.AddAsync(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<RolesEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.Roles.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.Remove(Entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return Entity;
        }

        public async Task<bool> DeleteAsyncBool(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(int id) => (await Get(id)).Role.Any();

        public async Task<RolesEntity> Get(int idEntity) => await _geoObservablesDBContext.Roles.FirstOrDefaultAsync(x => x.Id == idEntity);

        public async Task<RolesEntity> GetByRol(string rol) => await _geoObservablesDBContext.Roles.FirstOrDefaultAsync(x => x.Role == rol);

        public async Task<IEnumerable<RolesEntity>> GetAll() => await _geoObservablesDBContext.Set<RolesEntity>().ToListAsync();


        public async Task<RolesEntity> Update(int id, RolesEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Roles.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<RolesEntity> Update(RolesEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Roles.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }
    }
}
