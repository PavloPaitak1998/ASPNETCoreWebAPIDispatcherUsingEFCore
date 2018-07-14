using DataAccessLayer.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using FluentValidation.AspNetCore;
using Shared.Validators;
using Shared.DTO;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Implementation.Repositories;

namespace WebAppAirlineDispatcher
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DispatcherContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FlightDTOValidator>());
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<IPlaneService, PlaneService>();
            services.AddTransient<ICrewService, CrewService>();
            services.AddTransient<IPlaneTypeService, PlaneTypeService>();
            services.AddTransient<IDepartureService, DepartureService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DispatcherContext>();
                context.EnsureDatabaseSeeded();
            }

            app.UseMvc();
        }
    }
}
