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

        public DeactivateUsersCommandHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<UsersViewModel> Handle(DeactivateUsersCommand request, CancellationToken cancellationToken)
        {
            return UsersMapper.Map(await _usersServices.Deactivate(request.Mail));
        }
    }

}
