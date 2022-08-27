﻿using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Polly;

namespace GeoObservables.Api.Aplication.Services
{
    public class OriginServices : IOriginServices
    {
        private readonly IOriginRepository _originRepository;
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;

        public OriginServices(IOriginRepository originRepository, IAppConfig appConfig)
        {
            _originRepository = originRepository;
            _appConfig = appConfig;

            _maxTrys = _appConfig.MaxTrys();
            _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());
        }

        public async Task<OriginModel> AddOrigin(OriginModel origin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return OriginMapper.Map(await _originRepository.Add(OriginMapper.Map(origin)));
            });
        }

        public async Task<bool> DeleteOrigin(int idOrigin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _originRepository.DeleteAsyncBool(idOrigin);
            });
        }

        public async Task<IEnumerable<OriginModel>> GetAllOrigins()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (await _originRepository.GetAll()).Select(OriginMapper.Map);
            });
        }

        public async Task<OriginModel> GetOrigin(int idOrigin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return OriginMapper.Map(await _originRepository.Get(idOrigin));
            });
        }

        public async Task<OriginModel> UpdateOrigin(OriginModel origin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (OriginMapper.Map(await _originRepository.Update(OriginMapper.Map(origin))));
            });
        }
    }
}
