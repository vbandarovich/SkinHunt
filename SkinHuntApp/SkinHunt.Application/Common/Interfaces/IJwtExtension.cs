using Microsoft.AspNetCore.Identity;

namespace SkinHunt.Application.Common.Interfaces
{
    public interface IJwtExtension
    {
        Task<object> GenerateTokenAsync(IdentityUser user);
    }
}
