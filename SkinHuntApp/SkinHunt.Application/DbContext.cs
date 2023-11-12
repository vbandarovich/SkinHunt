﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application
{
    public class DbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<SkinEntity> Skins { get; set; }

        public DbSet<ItemTypeEntity> SkinTypes { get; set; }

        public DbSet<BasketEntity> Basket { get; set; }

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
