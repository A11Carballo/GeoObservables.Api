using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Commands.OriginCommands
{
    public class CreateOriginCommand : IRequest<OriginViewModel>
    {
        public OriginViewModel Origin { get; set; }
    }

    public class UpdateOriginCommand : IRequest<OriginViewModel>
    {
        public OriginViewModel Origin { get; set; }
    }

    public class DeleteOriginCommand : IRequest<bool>
    {
        public int IdOrigin { get; set; }
    }

    public class ExistOriginCommand : IRequest<bool>
    {
        public int IdOrigin { get; set; }
    }

}
