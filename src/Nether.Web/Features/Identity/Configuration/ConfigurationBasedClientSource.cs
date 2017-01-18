﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nether.Web.Features.Identity.Configuration
{
    public class ConfigurationBasedClientSource
    {
        private readonly ILogger _logger;
        public ConfigurationBasedClientSource(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<Client> LoadClients(IConfiguration configuration)
        {
            foreach (var clientConfig in configuration.GetChildren())
            {
                yield return ParseClient(clientConfig);
            }
        }
        /// <summary>
        /// Look up the client secret for the specified clientId in config
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public string GetClientSecret(IConfiguration configuration, string clientId)
        {
            var configClient = configuration.GetSection(clientId);
            if (configClient != null)
            {
                var secrets = ParseStringArray(configClient.GetSection("ClientSecrets")).ToArray();
                if (secrets != null && secrets.Length > 0)
                {
                    return secrets[0];
                }
            }
            return null;
        }

        private Client ParseClient(IConfigurationSection clientConfig)
        {
            var client = new Client
            {
                ClientId = clientConfig.Key
            };

            foreach (var configValue in clientConfig.GetChildren())
            {
                switch (configValue.Key)
                {
                    case "Name":
                        client.ClientName = configValue.Value;
                        break;
                    case "AllowAccessTokensViaBrowser":
                        client.AllowAccessTokensViaBrowser = ParseBool(configValue.Value);
                        break;
                    case "AccessTokenType":
                        client.AccessTokenType = ParseEnum<AccessTokenType>(configValue.Value);
                        break;
                    case "AllowedCorsOrigins":
                        client.AllowedCorsOrigins = ParseStringArray(configValue)
                                                        .ToList();
                        break;
                    case "AllowedGrantTypes":
                        client.AllowedGrantTypes = ParseStringArray(configValue);
                        break;
                    case "AllowedScopes":
                        client.AllowedScopes = ParseStringArray(configValue)
                                                    .ToList();
                        break;
                    case "ClientSecrets":
                        client.ClientSecrets = ParseStringArray(configValue)
                                                    .Select(v => new Secret(v.Sha256()))
                                                    .ToList();
                        break;
                    case "RedirectUris":
                        client.RedirectUris = ParseStringArray(configValue)
                                                    .ToList();
                        break;
                    case "PostLogoutRedirectUris":
                        client.PostLogoutRedirectUris = ParseStringArray(configValue)
                                                            .ToList();
                        break;
                    default:
                        // output a warning to the log for properties we don't recognise to aid debugging
                        _logger.LogWarning($"Identity:Clients - ignoring property '{configValue.Key}'");
                        break;
                }
            }

            return client;
        }


        private T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        private bool ParseBool(string value)
        {
            return bool.Parse(value);
        }

        private IEnumerable<string> ParseStringArray(IConfigurationSection configSection)
        {
            if (configSection.Value == null)
            {
                // when the config is specified using JSON it can come as child config elements
                // if specified in an arry
                return configSection.GetChildren()
                    .Select(v => v.Value);
            }
            else
            {
                // when specified via environment variables it comes in as a comma-delimited string
                return configSection.Value
                    .Split(',')
                    .Select(s => s.Trim());
            }
        }
    }
}
