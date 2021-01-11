using Microsoft.AspNetCore.Http;

namespace Diwash.SchoolSystem.Services
{
    public interface IUserService
    {
        public bool IsAuthenticated(HttpRequest request);
    }
}