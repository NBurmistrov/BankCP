using BankCP.Models.Accounts;
using BankCP.Models.Cards;
using BankCP.Models.Data;
using BankCP.Models.DBContext;
using BankCP.Models.Users;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankCP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<BankContext>()
                .AddScoped<DBManager>()
                .AddScoped<IRepository<Client>, Repository<Client>>()
                .AddScoped<IRepository<DebitCard>, Repository<DebitCard>>()
                .AddScoped<IRepository<CreditCard>, Repository<CreditCard>>()
                .AddScoped<IRepository<DebitAccount>, Repository<DebitAccount>>()
                .AddScoped<IRepository<CreditAccount>, Repository<CreditAccount>>()
                .AddScoped<IRepository<FixedDeposit>, Repository<FixedDeposit>>()
                .AddScoped<IRepository<Logs>, Repository<Logs>>()
                .AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
                .UseRouting()
                .UseStaticFiles()
                .UseHttpsRedirection()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
