using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, RolesViewModel>
    {
        private readonly IRolesServices _rolesServices;

        private readonly ILogger<UpdateRolesCommandHandler> _logger;

        public UpdateRolesCommandHandler(IRolesServices rolesServices, ILogger<UpdateRolesCommandHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<RolesViewModel> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UpdateRolesCommandHandler has been called.");

            return RolesMapper.Map(await _rolesServices.UpdateRol(RolesMapper.Map(request.Roles)));
        }
    }

}
