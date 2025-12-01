using Microsoft.AspNetCore.Authentication.Cookies;

namespace TaskManager.View.Configurations;

public static class AuthenticationConfiguration
{
    private const int CookieExpireDays = 7;
    private const string LoginPath = "/Account/Login";
    private const string AccessDeniedPath = "/Account/AccessDenied";
    private const string CookieName = "TaskManager.Auth";

    public static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddAuthentication("Cookies")
                .AddCookie("Cookies", ConfigureCookieOptions);
    }

    private static void ConfigureCookieOptions(CookieAuthenticationOptions options)
    {
        options.LoginPath = LoginPath;
        options.AccessDeniedPath = AccessDeniedPath;
        options.ExpireTimeSpan = TimeSpan.FromDays(CookieExpireDays);
        options.SlidingExpiration = true;

        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.Name = CookieName;
    }
}