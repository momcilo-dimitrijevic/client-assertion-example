namespace IntegrationApiClient.Config;

public class CertConfig
{
    public bool LoadCertFromFilesystem { get; set; }
    public string PathToPublicKey { get; set; }
    public string PathToPrivateKey { get; set; }
    public string KeyVaultName { get; set; }
    public string KeyVaultSecretName { get; set; }
}