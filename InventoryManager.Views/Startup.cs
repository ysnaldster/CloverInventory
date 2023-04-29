using InventoryManager.Application.Services;
using InventoryManager.Domain.Repositories;
using InventoryManager.Infrastructure;
using InventoryManager.Infrastructure.Repositories;
using InventoryManager.Views.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthenticationCore();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        var connectionString =
           "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=inventory_db;";
        services.AddNpgsql<InventoryManagerContext>(connectionString);
        services.AddScoped<ProtectedSessionStorage>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddScoped<ProductService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<StorageService>();
        services.AddScoped<WarehouseService>();
        services.AddScoped<StorageRepository>();
        services.AddScoped<UserService>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
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

        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<InventoryManagerContext>();
        context.Database.EnsureCreated();
    }
}