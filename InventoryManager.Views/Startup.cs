using InventoryManager.Application.Services;
using InventoryManager.Infrastructure;

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
        services.AddRazorPages();
        services.AddServerSideBlazor();
        //var connectionString =
          // "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=inventory_db;";
        //services.AddNpgsql<InventoryManagerContext>(connectionString);
        //services.AddScoped<UserService>();
  
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });

        //using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        //var context = serviceScope.ServiceProvider.GetRequiredService<InventoryManagerContext>();
        //context.Database.EnsureCreated();
    }
}