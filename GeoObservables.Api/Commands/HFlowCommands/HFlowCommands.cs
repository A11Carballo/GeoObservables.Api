using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Commands.HFlowCommands
{
    public class CreateHFlowdataCommand : IRequest<HFlowdataViewModel>
    {
        public HFlowdataViewModel HFlowdata { get; set; }
    }

    public class UpdateHFlowdataCommand : IRequest<HFlowdataViewModel>
    {
        public HFlowdataViewModel HFlowdata { get; set; }
    }

    public class DeleteHFlowdataCommand : IRequest<bool>
    {
        public int IdHFlow { get; set; }
    }

}
