using System.ComponentModel.DataAnnotations;
using GeoObservables.Api.Business.Aggregates;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Response.Roles
{
    public class RolesBoolResponse
    {
        public RolesBoolResponse()
        {
        }

        public RolesBoolResponse(bool response)
        {
            this.response = response;

            this.error = GeoResults.Ok;

            this.errorMessage = "Succesful";
        }


        public RolesBoolResponse(Exception ex)
        {
            this.response = false;

            this.error = GeoResults.GeneralError;

            this.errorMessage = ex.Message;
        }

        public bool response { get; set; }

        public string errorMessage { get; set; }

        public GeoResults error { get; set; }

    }
}
