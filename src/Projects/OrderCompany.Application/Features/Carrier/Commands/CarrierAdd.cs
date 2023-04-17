using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Carrier.Commands;

public static class CarrierAdd
{
    public record Command(CarrierAddDto CarrierAddDto) : IRequest<Response<NoDataDto>>;
    
    public class Handler: IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public Handler(ICarrierRepository carrierRepository, IMapper mapper)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Carrier>(request.CarrierAddDto);
            await _carrierRepository.AddAsync(data);
            return Response<NoDataDto>.Success(statusCode:200,message:"Carrier Added.");

        }
    }
}