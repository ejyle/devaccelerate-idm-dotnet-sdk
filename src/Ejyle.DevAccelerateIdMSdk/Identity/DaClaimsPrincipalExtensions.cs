﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Ejyle.DevAccelerate.IdM.Identity
{
    /// <summary>
    /// Contains a set of DevAccelerate IdM-specific extensions methods of <see cref="ClaimsPrincipal"/>.
    /// </summary>
    public static class DaClaimsPrincipalExtensions
    {
        /// <summary>
        /// Creates an instance <see cref="DaClaimsUser"/> based on a set of available claims.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>Returns an instance of the <see cref="DaClaimsUser"/> class.</returns>
        public static DaClaimsUser GetDaUser(this ClaimsPrincipal claimsPrincipal)
        {
            var claims = claimsPrincipal.Claims;

            if (claims == null || claims.Count() < 1)
            {
                return null;
            }

            var user = new DaClaimsUser();

            var roles = new List<string>();

            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "sub":
                        user.Id = claim.Value;
                        break;
                    case "preferred_username":
                        user.UserName = claim.Value;
                        break;
                    case "name":
                        user.Name = claim.Value;
                        break;
                    case "given_name":
                        user.FirstName = claim.Value;
                        break;
                    case "family_name":
                        user.LastName = claim.Value;
                        break;
                    case "email_verified":
                        user.IsEmailConfirmed = Convert.ToBoolean(claim.Value);
                        break;
                    case "email":
                        user.Email = claim.Value;
                        break;
                    case "role":
                        roles.Add(claim.Value);
                        break;
                    case "tenant":
                        user.Tenant = claim.Value;
                        break;
                }
            }

            user.Roles = roles.ToArray();
            return user;
        }
    }
}
