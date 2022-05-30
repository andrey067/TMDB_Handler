using AutoMapper;
using EscNet.IoC.Hashers;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using System.Text;
using Tmdb.API.ViewModels;
using Tmdb.Core.DTOs;
using Tmdb.Core.Options;
using Tmdb.Core.Results;
using Tmdb.CrossCutting.Http;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Context;
using Tmdb.Infra.Interfaces;
using Tmdb.Infra.UseCases;
using Tmdb.Services.Handlers.Commands;
using Tmdb.Services.Handlers.Queries;
using Tmdb.Services.Token;
using Tmdb.Services.UseCases;


namespace Tmdb.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void RegisterContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnectionString") ?? "Data Source=tmdb.db";
            var AutenticationConnectionString = configuration.GetConnectionString("AuthenticationDb") ?? "Data Source=authenticationDb.db";
            services.AddSqlite<TmdbContext>(connectionString);
            services.AddSqlite<AuthenticationContext>(AutenticationConnectionString);
        }

        public static async Task EnsureDBExists(IServiceProvider services)
        {
            var autenticationContext = services.CreateScope().ServiceProvider.GetRequiredService<AuthenticationContext>();
            await autenticationContext.Database.EnsureCreatedAsync();
            await autenticationContext.Database.MigrateAsync();

            var tbmdbContext = services.CreateScope().ServiceProvider.GetRequiredService<TmdbContext>();
            await tbmdbContext.Database.EnsureCreatedAsync();
            await tbmdbContext.Database.MigrateAsync();
        }

        public static void RegisterAutomapper(IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserDto, CreateUserCommand>();
                cfg.CreateMap<LoginDto, AuthenticationCommand>();
                cfg.CreateMap<AddProfileDto, AddProfileCommand>();
                cfg.CreateMap<AddMovieDto, AddMovieCommand>();
                cfg.CreateMap<TmdbResults, Movie>();
                cfg.CreateMap<SuggestedDto, GetMoviesSuggestedRequest>();
                cfg.CreateMap<AddWatchListDto, AddWatchListCommand>();
                cfg.CreateMap<AddWatchedDto, AddWatchedCommand>();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }

        public static void ConfiguracaoDependenciasHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateUserCommand, ResultModel>, CreateUserHandler>();
            services.AddScoped<IRequestHandler<AuthenticationCommand, ResultModel>, AuthenticationHandler>();
            services.AddScoped<IRequestHandler<FindAllMoviesRequest, ResultModel>, FindAllMoviesHandler>();
            services.AddScoped<IRequestHandler<AddProfileCommand, ResultModel>, AddProfileHandler>();
            services.AddScoped<IRequestHandler<GetAllProfilesRequest, ResultModel>, GetAllProfilesHandler>();
            services.AddScoped<IRequestHandler<AddMovieCommand, ResultModel>, AddMovieHandler>();
            services.AddScoped<IRequestHandler<GetMoviesSuggestedRequest, ResultModel>, GetMoviesSuggestedHandler>();
            services.AddScoped<IRequestHandler<SearchMovieRequest, ResultModel>, SearchMovieHandler>();
            services.AddScoped<IRequestHandler<AddWatchListCommand, ResultModel>, AddWatchListHandler>();
            services.AddScoped<IRequestHandler<AddWatchedCommand, ResultModel>, AddWatchedHandler>();
        }

        public static void RegisterHash(IServiceCollection services, IConfiguration configuration)
        {
            var config = new Argon2Config
            {
                Type = Argon2Type.DataDependentAddressing,
                Version = Argon2Version.Nineteen,
                Threads = Environment.ProcessorCount,
                TimeCost = int.Parse(configuration["Hash:TimeCost"]),
                MemoryCost = int.Parse(configuration["Hash:MemoryCost"]),
                Lanes = int.Parse(configuration["Hash:Lanes"]),
                HashLength = int.Parse(configuration["Hash:HashLength"]),
                Salt = Encoding.UTF8.GetBytes(configuration["Hash:Salt"])
            };
            services.AddArgon2IdHasher(config);
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGenerator, TokenGeneretor>();
            services.Configure<SettingsJWTOptions>(configuration.GetSection(SettingsJWTOptions.AppJwtSettings));
            services.Configure<TmdbOptions>(configuration.GetSection(TmdbOptions.TmdbOptionsSettings));
        }

        public static void RegisterAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["AppJwtSettings:SecretKey"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tmdb.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });
        }

        public static void RegisterRefit(IServiceCollection services, IConfiguration configuration)
        {
            string apikey = configuration["TmdbOptionsSettings:ApitKey"];
            string baseUrl = configuration["TmdbOptionsSettings:BaseUrl"];

            services.AddScoped(s => new ApiKeyMessageHandler(apikey));

            services.AddRefitClient<ITbdmSearchRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(baseUrl);
            }).AddHttpMessageHandler<ApiKeyMessageHandler>();
        }
    }
}