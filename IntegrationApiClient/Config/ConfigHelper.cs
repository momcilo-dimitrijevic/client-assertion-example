using Microsoft.Extensions.Configuration;

namespace IntegrationApiClient.Config;

public static class ConfigHelper
{
    public static ClientConfig ReadConfig()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        
        var configurationRoot = builder.Build();

        return configurationRoot.GetSection(nameof(ClientConfig)).Get<ClientConfig>();
    }
}