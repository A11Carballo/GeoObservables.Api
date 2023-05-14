﻿using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.HFlowCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers
{
    public class CreateHFlowdataCommandHandler : IRequestHandler<CreateHFlowdataCommand, HFlowdataViewModel>
    {
        private readonly IHFlowdataServices _hFlowdataServices;

        public CreateHFlowdataCommandHandler(IHFlowdataServices hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<HFlowdataViewModel> Handle(CreateHFlowdataCommand request, CancellationToken cancellationToken)
        {
            return HFlowdataMapper.Map(await _hFlowdataServices.AddHFlowdata(HFlowdataMapper.Map(request.HFlowdata)));
        }
    }

}
