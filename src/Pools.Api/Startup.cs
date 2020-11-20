using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pools.Api.Data.DBContext;
using Pools.Api.Services;

namespace Pools.Api
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
            
            services.AddDbContext<TradeDbContext>(opt =>
               opt.UseInMemoryDatabase("Trade"));
            services.AddDbContext<PoolDbContext>(opt =>
               opt.UseInMemoryDatabase("Pool"));
            services.AddTransient<IPoolRepository,PoolRepository>();
            services.AddControllers();

            services.AddDbContext<PoolContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PoolContext")));

            services.AddDbContext<TradeContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TradeContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
