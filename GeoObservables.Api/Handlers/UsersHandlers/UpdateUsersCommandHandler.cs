using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, UsersViewModel>
    {
        private readonly IUsersServices _usersServices;
        private readonly ILogger<UpdateUsersCommandHandler> _logger;

        public UpdateUsersCommandHandler(IUsersServices usersServices, ILogger<UpdateUsersCommandHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;
        }

        public async Task<UsersViewModel> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UpdateUsersCommand hasbeen called.");

            return UsersMapper.Map(await _usersServices.UpdateUser(UsersMapper.Map(request.Users)));
        }
    }

}
