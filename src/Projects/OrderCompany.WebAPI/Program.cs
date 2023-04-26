using Hangfire;
using OrderCompany.Application;
using OrderCompany.Application.Services.OrderReportService;
using OrderCompany.CrossCuttingConcerns.Exceptions;
using OrderCompany.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHangfireServer();
app.UseHangfireDashboard("/hangfire");


//app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var orderReportService = scope.ServiceProvider.GetRequiredService<IOrderReportService>();
    RecurringJob.AddOrUpdate(() => orderReportService.AddOrderReports(), Cron.Hourly);
}

app.Run();