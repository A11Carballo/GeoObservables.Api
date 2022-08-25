using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;

namespace GeoObservables.Api.Aplication.Services
{
    public class OriginServices : IOriginServices
    {
        private readonly IOriginRepository _originRepository;
        public OriginServices(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
        }

        public async Task<OriginModel> AddOrigin(OriginModel origin)
        {
            var addOrigin = await _originRepository.Add(OriginMapper.Map(origin));

            return OriginMapper.Map(addOrigin);
        }

        public async Task<bool> DeleteOrigin(int idOrigin)
        {
            var isDelete = await _originRepository.DeleteAsyncBool(idOrigin);

            return isDelete;
        }

        public async Task<IEnumerable<OriginModel>> GetAllOrigins()
        {
            var allOrigins = await _originRepository.GetAll();

            return allOrigins.Select(OriginMapper.Map);
        }

        public async Task<OriginModel> GetOrigin(int idOrigin)
        {
            var origin = await _originRepository.Get(idOrigin);

            return OriginMapper.Map(origin);
        }

        public async Task<OriginModel> UpdateOrigin(OriginModel origin)
        {
            var updOrigin = await _originRepository.Update(OriginMapper.Map(origin));

            return (OriginMapper.Map(updOrigin));
        }
    }
}
