using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Features.Carrier.Models;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Persistence.Paging;
using OrderCompany.Shared.Dtos;
using OrderCompany.Shared.Requests;

namespace OrderCompany.Application.Features.Carrier.Queries;

public static class GetAllCarrier
{
    public record Query(PageRequest PageRequest) : IRequest<Response<CarrierListModel>>;

    public class Handler : IRequestHandler<Query, Response<CarrierListModel>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public async Task<Response<CarrierListModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Carrier> carriers = await _carrierRepository.GetListAsync(
                include: x => x.Include(c => c.CarrierConfiguration
                )!,
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );
            CarrierListModel data = _mapper.Map<CarrierListModel>(carriers);
            return Response<CarrierListModel>.Success(data, "Carrier Listed.", 200);
        }
    }
}