﻿using System.Collections.Generic;
using IdentityServer4.Models;

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
                }
            };
        }

    }
}