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

        public CreateRolesCommandHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<UsersViewModel> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            return UsersMapper.Map(await _usersServices.AddUser(UsersMapper.Map(request.Users)));
        }
    }

}
