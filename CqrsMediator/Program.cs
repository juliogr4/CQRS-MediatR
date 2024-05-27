using CqrsMediator.Behaviours;
using CqrsMediator.DataStore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddSingleton<FakeDataStore>();

    builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavious<,>));
}

var app = builder.Build();
{
    app.MapControllers();
    app.UseHttpsRedirection();
    app.Run();
}

