using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RolesViewModel>>
    {
        private readonly IRolesServices _rolesServices;

        private readonly ILogger<GetAllRolesQueryHandler> _logger;

        public GetAllRolesQueryHandler(IRolesServices rolesServices, ILogger<GetAllRolesQueryHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<List<RolesViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetAllRolesQuery has been called.");

            var originList = await _rolesServices.GetAllRoles();

            return originList.Select(RolesMapper.Map).ToList();
        }
    }
}
