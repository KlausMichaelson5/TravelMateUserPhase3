using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TravelMate.Services;
using TravelMate2.Services;
using TravelMateUI.Services;


namespace TravelMateUI
{
    public class Program
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<LocalStorageService>();
            services.AddScoped<AuthService>();
            services.AddScoped<UserInfoService>();
            services.AddTransient<IUserUIService, UserUIService>();
            services.AddTransient<IHotelUIService, HotelUIService>();
            services.AddTransient<ICabUIService, CabUIService>();
            services.AddTransient<IAdminUIService, AdminUIService>();
            services.AddAuthorizationCore();

            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("RegularUser", policy => policy.RequireRole("Regular"));
                options.AddPolicy("HotelOwner", policy => policy.RequireRole("hotel_owner"));
                options.AddPolicy("DriverClient", policy => policy.RequireRole("driver_client"));
            });
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<ICustomAuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddTransient<ICabBookingUIService, CabBookingUIService>();
            services.AddTransient<ISearchUIService, SearchUIService>();
            services.AddTransient<IRoomUIService, RoomUIService>();
            services.AddTransient<IHotelBookingUIService, HotelBookingUIService>();
            services.AddTransient<IWishListUIService, WishListUIService>();
            services.AddTransient<IPackageProUIService, PackageProUIService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
           .AddCookie()
           .AddGoogle(options =>
           {
               options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
               options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
           });
        }
        public static IConfigurationRoot Configuration { get; set; }
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
			Configuration = builder.Configuration;

            builder.Services.AddTransient(sp => new HttpClient {});

            //builder.Services.AddHttpClient("Auth", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["AuthUrl"]);
            //});
            //builder.Services.AddHttpClient("Base", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            //});
            // builder.Services.AddHttpClient("Cab", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["CabUrl"]);
            //});
            // builder.Services.AddHttpClient("CabBooking", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["CabBooking"]);
            //});
            // builder.Services.AddHttpClient("Auth", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            //});
            // builder.Services.AddHttpClient("Auth", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            //});

            

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }
    }
}
