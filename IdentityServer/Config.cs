
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients
            => new Client[]
            {

            };

        public static IEnumerable<ApiScope> ApiScopes
            => new ApiScope[]
            {

            };

        public static IEnumerable<ApiResource> ApiResources
            => new ApiResource[]
            {

            };

        public static IEnumerable<IdentityResource> IdentityResources
            => new IdentityResource[]
            {

            };
    }
}