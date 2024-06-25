using Microsoft.AspNetCore.Identity;

namespace SkinHunt.Application.Common.Entities;

public class UserEntity : IdentityUser
{
    public double Balance { get; set; }
    
    public byte[] Avatar { get; set; }
}