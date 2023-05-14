using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetHFlowdataQuery : IRequest<HFlowdataViewModel>
    {
        public int IdHFlow { get; set; }
    }
}
