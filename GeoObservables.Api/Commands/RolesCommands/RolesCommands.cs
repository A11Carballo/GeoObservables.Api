using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Commands.RolesCommands
{
    public class CreateRolesCommand : IRequest<RolesViewModel>
    {
        public RolesViewModel Roles { get; set; }
    }

    public class UpdateRolesCommand : IRequest<RolesViewModel>
    {
        public RolesViewModel Roles { get; set; }
    }

    public class DeleteRolesCommand : IRequest<bool>
    {
        public int IdRoles { get; set; }
    }

    public class ExistRolesCommand : IRequest<bool>
    {
        public int IdRoles { get; set; }
    }

}
