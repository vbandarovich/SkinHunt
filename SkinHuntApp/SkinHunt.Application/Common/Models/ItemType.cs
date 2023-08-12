using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Common.Enums;

namespace SkinHunt.Application.Common.Models
{
    public class ItemType : BaseEntity
    {
        public Category Category { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}
