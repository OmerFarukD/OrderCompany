using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Features.Carrier.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Carrier.Commands;

public static class CarrierUpdate
{
    public record Command(CarrierUpdateDto CarrierUpdateDto) : IRequest<Response<NoDataDto>>;

    public class Handler : IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;
        private readonly CarrierBusinessRules _carrierBusinessRules;

        public Handler(ICarrierRepository carrierRepository, IMapper mapper, CarrierBusinessRules carrierBusinessRules)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
            _carrierBusinessRules = carrierBusinessRules;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Carrier>(request.CarrierUpdateDto);

            await _carrierBusinessRules.CarrierIsFound(data.Id);

            await _carrierRepository.UpdateAsync(data);
            return Response<NoDataDto>.Success(message:"Carrier is Updated",statusCode:200);
        }
    }
}