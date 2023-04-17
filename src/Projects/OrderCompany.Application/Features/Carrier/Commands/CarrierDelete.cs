using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Carrier.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Carrier.Commands;

public static class CarrierDelete
{
    public record Command(int Id) : IRequest<Response<NoDataDto>>;
    
    public class Handler: IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly CarrierBusinessRules _carrierBusinessRules;
        private readonly ICarrierRepository _carrierRepository;
        
        public Handler( CarrierBusinessRules carrierBusinessRules, ICarrierRepository carrierRepository)
        {
            _carrierBusinessRules = carrierBusinessRules;
            _carrierRepository = carrierRepository;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            await _carrierBusinessRules.CarrierIsFound(request.Id);
            var data = _carrierRepository.Get(x => x.Id.Equals(request.Id));
            await _carrierRepository.DeleteAsync(data);

            return Response<NoDataDto>.Success(200, "Carrier is Deleted.");
        }
    }
}