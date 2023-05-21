using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class DeactivateUsersCommandHandler : IRequestHandler<DeactivateUsersCommand, UsersViewModel>
    {
        private readonly IUsersServices _usersServices;

        private readonly ILogger<DeactivateUsersCommandHandler> _logger;

        public DeactivateUsersCommandHandler(IUsersServices usersServices, ILogger<DeactivateUsersCommandHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;
        }

        public async Task<UsersViewModel> Handle(DeactivateUsersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeactivateUsersCommand has been called.");

            return UsersMapper.Map(await _usersServices.Deactivate(request.Mail));
        }
    }

}
