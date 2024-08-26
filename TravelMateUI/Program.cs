using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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
            builder.Services.AddTransient<ISearchUIService, SearchUIService>();
            builder.Services.AddTransient<IRoomUIService, RoomUIService>();
            builder.Services.AddTransient<IHotelBookingUIService, HotelBookingUIService>();
            builder.Services.AddTransient<IWishListUIService, WishListUIService>();
            builder.Services.AddTransient<IPackageProUIService, PackageProUIService>();
            await builder.Build().RunAsync();
        }
    }
}
