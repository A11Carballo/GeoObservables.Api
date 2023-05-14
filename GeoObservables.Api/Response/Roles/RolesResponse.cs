using GeoObservables.Api.Business.Aggregates;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Response.Roles
{
    public class RolesResponse
    {
        public RolesResponse()
        {
        }

        public RolesResponse(List<RolesViewModel> rolesViewModelList)
        {
            this.rolesViewModelList = rolesViewModelList;

            error = GeoResults.Ok;

            errorMessage = "Succesful";
        }

        public RolesResponse(RolesViewModel rolesViewModel)
        {
            List<RolesViewModel> RolesViewModelList = new();

            RolesViewModelList.Add(rolesViewModel);

            this.rolesViewModelList = RolesViewModelList;

            this.error = GeoResults.Ok;

            this.errorMessage = "Succesful";
        }

        public RolesResponse(List<RolesViewModel> rolesViewModelList, Exception ex)
        {
            this.rolesViewModelList = rolesViewModelList;

            this.error = GeoResults.GeneralError;

            this.errorMessage = ex.Message;
        }

        public List<RolesViewModel> rolesViewModelList { get; set; }

        public string errorMessage { get; set; }

        public GeoResults error { get; set; }

    }
}
