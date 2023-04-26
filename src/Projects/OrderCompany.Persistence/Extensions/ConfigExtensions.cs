using Microsoft.Extensions.Configuration;

namespace OrderCompany.Persistence.Extensions;

public static class ConfigExtensions
{
    public static string GetBackgroundJobString(this IConfiguration configuration, string name)
    {
        return configuration?.GetSection("BackGroundJobStrings")?[name];
    }
}