using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoObservables.Api.DataAccess.Repositories
{
    public class HFlowdataRepository : IHFlowdataRepository
    {
        private readonly IGeoObservablesDBContext _geoObservablesDBContext;

        public HFlowdataRepository(IGeoObservablesDBContext geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<HFlowdataEntity> Add(HFlowdataEntity entity)
        {
            await _geoObservablesDBContext.HFlowdata.AddAsync(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<HFlowdataEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.HFlowdata.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.HFlowdata.Remove(Entity);

            await _geoObservablesDBContext.SaveChangesAsync();

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

        public async Task<HFlowdataEntity> Get(int idEntity) => await _geoObservablesDBContext.HFlowdata.Include(x => x.User).ThenInclude(y=> y.Roles).FirstOrDefaultAsync(x => x.Id == idEntity);


        public async Task<IEnumerable<HFlowdataEntity>> GetAll() => await _geoObservablesDBContext.HFlowdata.ToListAsync();


        public async Task<HFlowdataEntity> Update(int id, HFlowdataEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.HFlowdata.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<HFlowdataEntity> Update(HFlowdataEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.HFlowdata.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<IEnumerable<HFlowdataEntity>> GetByFilter(Expression<Func<HFlowdataEntity, bool>> filter = null) => await _geoObservablesDBContext.Set<HFlowdataEntity>().Where(filter).ToListAsync();
    }
}
