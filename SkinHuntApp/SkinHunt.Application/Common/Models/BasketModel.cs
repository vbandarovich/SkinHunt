using Microsoft.AspNetCore.Identity;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Common.Models
{
    public class BasketModel
    {
        public IdentityUser UserId { get; set; }

        public SkinEntity SkinId { get; set;}

        public DateTime Data { get; set; }
    }
}
