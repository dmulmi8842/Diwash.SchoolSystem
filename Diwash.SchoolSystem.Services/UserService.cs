using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _authenticatedUsers = new List<User>
        {
            new User{ Name = "Bob", Password = "abc123"},
            new User{ Name = "MSI", Password = "7399"}
        };

        public bool IsAuthenticated(HttpRequest request)
        {
            AuthenticationHeaderValue.TryParse(request.Headers["Authorization"], out var authorizationHeader);

            if (authorizationHeader == null) return false;
            if (authorizationHeader.Scheme != "Basic") return false;
            if (authorizationHeader.Parameter == null) return false;

            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeader.Parameter)).Split(new[] { ':'},2);
            if (credentials.Length < 2) return false;

            var userName = credentials[0];
            var password = credentials[1];

            var user = _authenticatedUsers.FirstOrDefault(x => x.Name == userName);
            if (user == null) return false;
            if (user.Password != password) return false;

            return true;
        }
    }
}
