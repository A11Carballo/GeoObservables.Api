using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Commands.UsersCommands
{
    public class CreateUsersCommand : IRequest<UsersViewModel>
    {
        public UsersViewModel Users { get; set; }
    }

    public class UpdateUsersCommand : IRequest<UsersViewModel>
    {
        public UsersViewModel Users { get; set; }
    }

    public class DeleteUsersCommand : IRequest<bool>
    {
        public int IdUsers { get; set; }
    }

    public class ExistUsersCommand : IRequest<bool>
    {
        public int IdUsers { get; set; }
    }

}
