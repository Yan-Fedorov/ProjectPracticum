using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.WebApi
{
    public static class ClaimsExstensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(
                claimsPrincipal.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value
                );
        }
    }
}
