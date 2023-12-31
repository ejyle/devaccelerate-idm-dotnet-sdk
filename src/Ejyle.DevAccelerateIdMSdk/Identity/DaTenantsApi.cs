﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.IdM.Identity
{
    /// <summary>
    /// Represents a wrapper of the /tenants API of DevAccelerate IdM.
    /// </summary>
    public class DaTenantsApi : DaApiConsumer
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaTenantsApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public DaTenantsApi(string address, string apiVersion, string accessToken)
            : base(address, apiVersion, accessToken) { }


        /// <summary>
        /// Creates an instance of the <see cref="DaTenantsApi"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public DaTenantsApi(string address, string accessToken)
        : base(address, accessToken) { }

        /// <summary>
        /// Creates an instance of the <see cref="DaTenantsApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public DaTenantsApi(string accessToken)
        : base(accessToken) { }

        /// <summary>
        /// Gets a list of tenants as a JSON string.
        /// </summary>
        public async Task<string> GetTenantsAsStringAsync()
        {
            return await GetStringAsync("tenants");
        }

        /// <summary>
        /// Gets a tenant by tenant ID as a JSON string.
        /// </summary>
        /// <param name="id">The ID of the tenant.</param>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetTenantsByIdAsStringAsync(string id)
        {
            return await GetStringAsync("tenants", new Dictionary<string, string> {{ "id", id }});
        }

        /// <summary>
        /// Gets a list of tenants.
        /// </summary>
        /// <returns>Returns an array of <see cref="DaTenant"/>.</returns>
        public async Task<DaTenant[]> GetTenantsAsync()
        {
            var tenants = await GetArrayAsync<DaTenant>("tenants");
            return tenants;
        }

        /// <summary>
        /// Gets a tenant by ID.
        /// </summary>
        /// <param name="id">The ID of the tenant.</param>
        /// <returns>Returns an instance of the <see cref="DaTenant"/> class.</returns>
        public async Task<DaTenant> GetTenantByIdAsync(string id)
        {
            return await GetAsync<DaTenant>("tenants", new Dictionary<string, string> { { "id", id } });
        }
    }
}
