using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class CreateRolesCommandHandler : IRequestHandler<CreateUsersCommand, UsersViewModel>
    {
        private readonly IUsersServices _usersServices;

        private readonly ILogger<CreateRolesCommandHandler> _logger;

        public CreateRolesCommandHandler(IUsersServices usersServices, ILogger<CreateRolesCommandHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;   
        }

        public async Task<UsersViewModel> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateUsersCommand has been called.");

            return UsersMapper.Map(await _usersServices.AddUser(UsersMapper.Map(request.Users)));
        }
    }

}
