using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_api1") {Scopes = { "api1_read", "api1_write", "api1_update"}, ApiSecrets = new[] {new Secret("secretApi1".Sha256())}},
                new ApiResource("resource_api2") {Scopes = { "api2_read", "api2_write", "api2_update"}, ApiSecrets = new[] {new Secret("secretApi2".Sha256())}}
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api1_read", "API 1 için okuma izni"),
                new ApiScope("api1_write", "API 1 için yazma izni"),
                new ApiScope("api1_update", "API 1 için güncelleme izni"),

                new ApiScope("api2_read", "API 2 için okuma izni"),
                new ApiScope("api2_write", "API 2 için yazma izni"),
                new ApiScope("api2_update", "API 2 için güncelleme izni")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Client1",
                    ClientName = "Client 1 Application",
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1_read" }
                },

                new Client
                {
                    ClientId = "Client2",
                    ClientName = "Client 2 Application",
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1_read", "api1_update", "api2_write", "api2_update" }
                },

                new Client
                {
                    ClientId = "Client1-MVC",
                    RequirePkce = false,
                    ClientName = "Client 1 MVC Application",
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string> { "https://localhost:5003/signin-oidc" },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1", Username = "vedatermis", Password = "password", Claims = new List<Claim>
                    {
                        new Claim("given_name", "Vedat"),
                        new Claim("family_name", "ERMIS")
                    }

                },
                new TestUser
                {
                    SubjectId = "2", Username = "merveermis", Password = "password", Claims = new List<Claim>
                    {
                        new Claim("given_name", "Merve"),
                        new Claim("family_name", "ERMIS")
                    }

                }
            };
        }
    }
}