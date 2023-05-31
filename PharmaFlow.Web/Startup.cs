using PharmaFLow.DataAccess.DbContexts;
using PharmaFLow.DataAccess.Persistences.Contacts;
using PharmaFLow.DataAccess.Repositories;

namespace PharmaFlow.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddRazorPages();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.AccessDeniedPath = new PathString("/Identity/Account/Login");
            });

        // Database settings.
        services.AddDbContext<PharmaFlowDbContext>();

        //DI.
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IMedicalFacilityRepository, MedicalFacilityRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IMeetRepository, MeetRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<PharmaFlowDbContext>();
            context.Database.Migrate();
            context.SeedUsers();
            context.SeedProducts();
            context.SeedMedicalFacilities();
        }

        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area=Pharmacist}/{controller=Calendar}/{action=GetCalendar}"
            );
        });
    }
}
