using MediatR;
using OrderCompany.Application.Services.OrderReportService;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.CarrierReports.Commands;

public static class AddReport
{
    public record Command() : IRequest<Response<NoDataDto>>;

    public class Handler : IRequestHandler<Command, Response<NoDataDto>>

    {
        private readonly ICarrierReportRepository _carrierReportRepository;

        public Handler(ICarrierReportRepository carrierReportRepository)
        {
            _carrierReportRepository = carrierReportRepository;
        }


        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            await _carrierReportRepository.AddReports();
            return Response<NoDataDto>.Success(200,"ReportsAdded");
        }
        
    }
}