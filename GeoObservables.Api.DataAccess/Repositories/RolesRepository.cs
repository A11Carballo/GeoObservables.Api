using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
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
            this._geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<RolesEntity> Add(RolesEntity entity)
        {
            await this._geoObservablesDBContext.Roles.AddAsync(entity);

            await this._geoObservablesDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<RolesEntity> DeleteAsync(int idEntity)
        {
            var Entity = await this._geoObservablesDBContext.Roles.SingleAsync(x => x.Id == idEntity);

            this._geoObservablesDBContext.Remove(Entity);

            await this._geoObservablesDBContext.SaveChangesAsync();

            return Entity;
        }

        public async Task<bool> DeleteAsyncBool(int idEntity)
        {
            var entityDelete = await this._geoObservablesDBContext.Roles.SingleAsync(x => x.Id == idEntity);

            if (entityDelete != null)
            {
                this._geoObservablesDBContext.Roles.Remove(entityDelete);

                await this._geoObservablesDBContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> Exist(int id) => (await Get(id)).Role.Any();

        public async Task<RolesEntity> Get(int idEntity) => await this._geoObservablesDBContext.Roles.FirstOrDefaultAsync(x => x.Id == idEntity);

        public async Task<RolesEntity> GetByRol(string rol) => await this._geoObservablesDBContext.Roles.FirstOrDefaultAsync(x => x.Role == rol);

        public async Task<IEnumerable<RolesEntity>> GetAll() => await this._geoObservablesDBContext.Set<RolesEntity>().ToListAsync();


        public async Task<RolesEntity> Update(int id, RolesEntity entity)
        {
            var updateEntity = this._geoObservablesDBContext.Roles.Update(entity);

            await this._geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<RolesEntity> Update(RolesEntity entity)
        {
            var updateEntity = this._geoObservablesDBContext.Roles.Update(entity);

            await this._geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<IEnumerable<RolesEntity>> GetByFilter(Expression<Func<RolesEntity, bool>> filter = null) =>  await this._geoObservablesDBContext.Set<RolesEntity>().Where(filter).ToListAsync();  
    }
}
