﻿using System;
using System.Linq.Expressions;
using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoObservables.Api.DataAccess.Repositories
{
    public class OriginRepository : IOriginRepository
    {
        private readonly IGeoObservablesDBContext _geoObservablesDBContext;

        public OriginRepository(IGeoObservablesDBContext geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<OriginEntity> Add(OriginEntity entity)
        {
            await _geoObservablesDBContext.Origin.AddAsync(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<OriginEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.Origin.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.Origin.Remove(Entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return Entity;
        }

        public async Task<bool> DeleteAsyncBool(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(int id) => (await Get(id)).OriginInfo.Any();

        public async Task<OriginEntity> Get(int idEntity) => await _geoObservablesDBContext.Origin.Include(x => x.HFlowdata).FirstOrDefaultAsync(x => x.Id == idEntity);


        public async Task<IEnumerable<OriginEntity>> GetAll() => await _geoObservablesDBContext.Origin.ToListAsync();


        public async Task<OriginEntity> Update(int id, OriginEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Origin.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<OriginEntity> Update(OriginEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Origin.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<IEnumerable<OriginEntity>> GetByFilter(Expression<Func<OriginEntity, bool>> filter = null) => await _geoObservablesDBContext.Set<OriginEntity>().Where(filter).ToListAsync();
    }
}
