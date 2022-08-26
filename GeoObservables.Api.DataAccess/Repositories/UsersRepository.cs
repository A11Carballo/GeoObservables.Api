using GeoObservables.Api.DataAccess.Contracts;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;


namespace GeoObservables.Api.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IGeoObservablesDBContext _geoObservablesDBContext;

        public UsersRepository(IGeoObservablesDBContext geoObservablesDBContext)
        {
            _geoObservablesDBContext = geoObservablesDBContext;
        }

        public async Task<UsersEntity> Add(UsersEntity entity)
        {
            await _geoObservablesDBContext.Users.AddAsync(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UsersEntity> DeleteAsync(int idEntity)
        {
            var Entity = await _geoObservablesDBContext.Users.SingleAsync(x => x.Id == idEntity);

            _geoObservablesDBContext.Users.Remove(Entity);

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

        public async Task<UsersEntity> Get(int idEntity) => await _geoObservablesDBContext.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == idEntity);


        public async Task<IEnumerable<UsersEntity>> GetAll() => await _geoObservablesDBContext.Set<UsersEntity>().ToListAsync();

        public async Task<UsersEntity> Update(int id, UsersEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Users.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<UsersEntity> Update(UsersEntity entity)
        {
            var updateEntity = _geoObservablesDBContext.Users.Update(entity);

            await _geoObservablesDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }
    }
}
