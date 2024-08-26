using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TravelMate.Services;
using TravelMate2.Services;
using TravelMateUI.Services;

namespace TravelMateUI
{
    public class Program
    {
		public static IConfigurationRoot Configuration { get; set; }
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
			Configuration = builder.Configuration;
			builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseUrl"]) });
            builder.Services.AddScoped<LocalStorageService>();
			builder.Services.AddScoped<AuthService>();
			builder.Services.AddScoped<UserInfoService>();
			builder.Services.AddTransient<IUserUIService, UserUIService>();
            builder.Services.AddTransient<IHotelUIService, HotelUIService>();
            builder.Services.AddTransient<ICabUIService, CabUIService>();
            builder.Services.AddTransient<IAdminUIService, AdminUIService>();
            builder.Services.AddAuthorizationCore();
      
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("RegularUser", policy => policy.RequireRole("Regular"));
                options.AddPolicy("HotelOwner", policy => policy.RequireRole("hotel_owner"));
                options.AddPolicy("DriverClient", policy => policy.RequireRole("driver_client"));
            });
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<ICustomAuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddTransient<ICabBookingUIService, CabBookingUIService>();
            builder.Services.AddTransient<ISearchUIService, SearchUIService>();
            builder.Services.AddTransient<IRoomUIService, RoomUIService>();
            builder.Services.AddTransient<IHotelBookingUIService, HotelBookingUIService>();
            builder.Services.AddTransient<IWishListUIService, WishListUIService>();
            builder.Services.AddTransient<IPackageProUIService, PackageProUIService>();
            await builder.Build().RunAsync();
        }
    }
}
