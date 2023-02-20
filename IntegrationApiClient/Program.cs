// See https://aka.ms/new-console-template for more information

using IntegrationApiClient;
using IntegrationApiClient.Config;
using Microsoft.Identity.Client;

Console.WriteLine("--- Obtaining token ---");

var config = ConfigHelper.ReadConfig();
var certificate = CertificateHelper.Get(config);

var clientId = config.AuthConfig.ClientId;
var tenantId = config.AuthConfig.TenantId;
var app = ConfidentialClientApplicationBuilder.Create(clientId)
    .WithCertificate(certificate)
    .Build();

var authResult = await app.AcquireTokenForClient(scopes: new [] {  $"{clientId}/.default"})
    .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
    .ExecuteAsync();
    
Console.WriteLine($"{authResult.AccessToken}");

Console.WriteLine("--- Finished ---");