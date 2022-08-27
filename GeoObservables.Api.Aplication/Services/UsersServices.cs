using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Polly;

namespace GeoObservables.Api.Aplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly IUsersRepository _usersRepository;
        public UsersServices(IUsersRepository usersRepository, IAppConfig appConfig)
        {
            _usersRepository = usersRepository;
            _appConfig = appConfig;

            _maxTrys = _appConfig.MaxTrys();
            _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());
        }

        public async Task<UsersModel> GetUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Get(idUser));
            });
        }

        public async Task<UsersModel> AddUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Add(UsersMapper.Map(user)));
            });
        }

       public async Task<IEnumerable<UsersModel>> GetAllUsers()
       {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (await _usersRepository.GetAll()).Select(UsersMapper.Map);
            });
        }

        public async Task<UsersModel> UpdateUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Update(UsersMapper.Map(user)));
            });
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _usersRepository.DeleteAsyncBool(idUser);
            });
        }
    }
}
