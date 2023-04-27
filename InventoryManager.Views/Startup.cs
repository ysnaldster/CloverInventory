using InventoryManager.Application.Services;
using InventoryManager.Domain.Entities;
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
        services.AddScoped<IGenericRestRepository<Category>, CategoryRepository>();
        services.AddScoped<IGenericRestRepository<Product>, ProductRepository>();
        services.AddScoped<IGenericRestRepository<User>, UserRepository>();
        services.AddScoped<IGenericRestRepository<Storage>, StorageRepository>();
        services.AddScoped<IGenericRestRepository<Warehouse>, WarehouseRepository>();
        services.AddScoped<IGenericRestRepository<TransactionLog>, TransactionLogRepository>();
        services.AddScoped<StorageRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<ProductService>();
        services.AddScoped<StorageService>();
        services.AddScoped<WarehouseService>();
        services.AddScoped<TransactionLogService>();
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