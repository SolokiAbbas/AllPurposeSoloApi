using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    var daco = new DefaultAzureCredentialOptions
                    {
                        ExcludeInteractiveBrowserCredential = false,
                        SharedTokenCacheTenantId = "c1ca7478-cd2a-497e-9c5c-8347e82257a5"
                    };
                    var builtConfig = config.Build();
                    var secretClient = new SecretClient(
                        new Uri(builtConfig["Azure:Keyvault"]),
                        new DefaultAzureCredential(daco));
                    config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
                });
    }
}
