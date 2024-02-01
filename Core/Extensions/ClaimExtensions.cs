using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddFirstName(this ICollection<Claim> claims, string firstName)
        {
            claims.Add(new Claim("FirstName", firstName));
        }

        public static void AddLastName(this ICollection<Claim> claims, string lastName)
        {
            claims.Add(new Claim("LastName", lastName));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddDescription(this ICollection<Claim> claims, string description)
        {
            claims.Add(new Claim("Description", description));
        }

        public static void AddIdentityNumber(this ICollection<Claim> claims, string identityNumber)
        {
            claims.Add(new Claim("IdentityNumber", identityNumber));
        }

        public static void AddPhoto(this ICollection<Claim> claims, string photoPath)
        {
            claims.Add(new Claim("PhotoPath", photoPath));
        }

        public static void AddTitle(this ICollection<Claim> claims, string title)
        {
            claims.Add(new Claim("Title", title));
        }
    }
}