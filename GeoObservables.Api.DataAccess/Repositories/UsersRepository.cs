using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;


namespace GeoObservables.Api.DataAccess.Repositories
{
    public class UsersRepository : Lazy<IUsersRepository>
    {
        private readonly Lazy<IGeoObservablesDBContext> _geoObservablesDBContext;

        public UsersRepository(Lazy<IGeoObservablesDBContext> geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<UsersEntity> Add(UsersEntity entity)
        {
            await _geoObservablesDBContext.Value.Users.AddAsync(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return entity;
        }

        public async Task<UsersEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.Value.Users.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.Value.Users.Remove(Entity);

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

        public async Task<UsersEntity> Get(int idEntity) => await _geoObservablesDBContext.Value.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == idEntity);


        public async Task<IEnumerable<UsersEntity>> GetAll() => await _geoObservablesDBContext.Value.Set<UsersEntity>().ToListAsync();

        public async Task<UsersEntity> Update(int id, UsersEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Value.Users.Update(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<UsersEntity> Update(UsersEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Value.Users.Update(entity);

            await _geoObservablesDBContext.Value.SaveChangesAsync();

            return updateEntity.Entity;
        }
    }
}
