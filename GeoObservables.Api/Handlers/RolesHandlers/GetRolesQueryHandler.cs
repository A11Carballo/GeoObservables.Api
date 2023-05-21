using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RolesViewModel>
    {
        private readonly IRolesServices _rolesServices;

        private readonly ILogger<GetRolesQueryHandler> _logger;

        public GetRolesQueryHandler(IRolesServices rolesServices, ILogger<GetRolesQueryHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<RolesViewModel> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetRolesQuery has been called.");

            return RolesMapper.Map(await _rolesServices.GetRol(request.IdRoles));
        }
    }
}
