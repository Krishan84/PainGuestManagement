using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PainGuestApplication.Model;
using PainGuestApplication.Model.Repositories;

namespace PainGuestApplication
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
            services.AddDbContext<UserIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PainGuestApplication.Model")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UserIdentityDbContext>().AddDefaultTokenProviders();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddScoped<UserIdentityDbContext, UserIdentityDbContext>();
            services.AddScoped<ApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<B2BAccountRepository, B2BAccountRepository>();
            services.AddScoped<B2BAccountRoomRepository, B2BAccountRoomRepository>();
            services.AddScoped<BankAccountInformationRepository, BankAccountInformationRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();
            services.AddScoped<PainGuestAgreementRepository, PainGuestAgreementRepository>();
            services.AddScoped<PainGuestRoomAllotmentRepository, PainGuestRoomAllotmentRepository>();
            services.AddScoped<RentTransactionRepository, RentTransactionRepository>();
            services.AddScoped<ReviewRepository, ReviewRepository>();
            services.AddScoped<TermsAndConditionsRepository, TermsAndConditionsRepository>();
            services.AddScoped<UserTermsAcceptanceRepository, UserTermsAcceptanceRepository>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder.WithOrigins(Configuration["ClientConfig:BaseUrl"]).AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
