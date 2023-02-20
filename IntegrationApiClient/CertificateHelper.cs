using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using IntegrationApiClient.Config;

namespace IntegrationApiClient;

public static class CertificateHelper
{
    public static X509Certificate2 Get(ClientConfig clientConfig)
    {
        return clientConfig.CertConfig.LoadCertFromFilesystem
            ? X509Certificate2.CreateFromPemFile(clientConfig.CertConfig.PathToPublicKey, clientConfig.CertConfig.PathToPrivateKey)
            : new CertificateClient(
                    vaultUri: new Uri($"https://{clientConfig.CertConfig.KeyVaultName}.vault.azure.net/"), 
                    credential: new DefaultAzureCredential())
                .DownloadCertificate(clientConfig.CertConfig.KeyVaultSecretName)
                .Value;
    }
}