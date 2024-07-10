using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Notificacoes;
using ApiJobs.Context;
using ApiJobs.Data;
using ApiJobs.Data.Repository;
using ApiJobs.Extensions;
using ApiJobs.Repository;
using ApiJobs.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiJobs.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbJobsContext>();
            services.AddScoped<IEmpresaVagaRepository, EmpresaVagaRepository>();
            services.AddScoped<IEmpresaVagaService, EmpresaVagaService>();
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
