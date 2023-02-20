# Client credentials flow in Azure AD B2C

## JWT bearer client assertion (signed with a certificate)

Docs:
* https://learn.microsoft.com/en-us/azure/active-directory/develop/active-directory-certificate-credentials

### User secrets

```
{
  "ClientConfig": {
    "AuthConfig": {
      "TenantId": "{AZURE_AD_TENANT_ID}",
      "ClientId": "{APPLICATION_CLIENT_ID}"
    },
    "CertConfig": {
      // set this to false if you want to use an Azure KeyVault
      "LoadCertFromFilesystem": false,
      // used only if LoadCertFromFilesystem is 'true' 
      "PathToPublicKey": "Scripts/example.crt",
      "PathToPrivateKey": "Scripts/example.key",
      // used only if LoadCertFromFilesystem is 'false'
      "KeyVaultName": "{KEYVAULT_NAME}",
      "KeyVaultSecretName": "{CERTIFICATE_NAME}"
    }
  }
}
```

### Helper scripts

Run Scripts/generate-cert.sh to generate a self-signed certificate that can be used for testing.

Steps:

1. Run the script and generate a certificate
2. Set user secrets paths to target public/private keys
3. Upload the public key to Azure AD (B2C)
4. Use the certificate to sign a jwt client assertion and obtain an access token
