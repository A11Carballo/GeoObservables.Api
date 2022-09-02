using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.Aplication.Unit.Test.Stubs
{
    public static class RolesStub
    {
        public static RolesEntity roles_1 = new RolesEntity()
        {
            Id = 1,
            Role = "Admin"
        };

        public static RolesEntity roles_2 = new RolesEntity()
        {
            Id = 2,
            Role = "User"
        };

        public static IEnumerable<RolesEntity> rolesList = new List<RolesEntity>(new RolesEntity[] {roles_1, roles_2});

    }
}
