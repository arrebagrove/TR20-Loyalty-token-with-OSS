using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class KeyVaultClient
    {
        string clientId = "3cd1ed80-3fd6-470e-b7b4-87142860837f";
        string clientSecret = "r_@Oon9UxwaPt1C3A@1N/[hAJK*0PA6=";

        Microsoft.Azure.KeyVault.KeyVaultClient kvClient;

        public async Task<SecretBundle> ReadSecret(string pubKey)
        {
            string kvUrl = "https://ready20kv.vault.azure.net/";
            kvClient = new Microsoft.Azure.KeyVault.KeyVaultClient(GetToken);

            return await kvClient.GetSecretAsync(kvUrl, pubKey);
        }

        private async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(
                clientId,
                clientSecret);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }

    }
}