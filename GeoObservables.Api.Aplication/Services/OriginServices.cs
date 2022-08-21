using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.DataAccess.Contracts.Repositories;

namespace GeoObservables.Api.Aplication.Services
{
    public class OriginServices : IOriginServices
    {
        private readonly IOriginRepository _originRepository;
        public OriginServices(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
        }

        public async Task<string> GetOrigin(int idOrigin)
        {
            var origin = await _originRepository.Get(idOrigin);

            return origin.OriginInfo;
        }
    }
}
