using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetOriginQuery : IRequest<OriginViewModel>
    {
        public int IdOrigin { get; set; }
    }
}
