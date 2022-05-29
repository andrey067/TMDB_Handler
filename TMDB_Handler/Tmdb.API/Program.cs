using MediatR;
using Tmdb.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

ConfigureService.RegisterContext(builder.Services, builder.Configuration);
ConfigureService.RegisterAutomapper(builder.Services);
ConfigureService.ConfiguracaoDependenciasHandlers(builder.Services);
ConfigureService.RegisterHash(builder.Services, builder.Configuration);
ConfigureService.RegisterServices(builder.Services, builder.Configuration);
ConfigureService.RegisterAuthentication(builder.Services, builder.Configuration);
ConfigureService.RegisterSwagger(builder.Services);
ConfigureService.RegisterRefit(builder.Services, builder.Configuration);

ConfigureRepository.ConfigureDependenciesRepository(builder.Services);
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

await ConfigureService.EnsureDBExists(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
