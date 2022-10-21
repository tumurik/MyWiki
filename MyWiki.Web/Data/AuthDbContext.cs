using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MyWiki.Web.Data
{
    public class AuthDbContext : IdentityDbContext<MyWikiUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "469680c0-fc6e-4099-b20e-04ad3dd67d11";
            var userRoleId = "e7ec7f78-bcc9-40d5-a62e-df71d1695367";

            // Seed Roles - User, Admin
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<MyWikiUser>()
                .Property(e => e.Department)
            .HasMaxLength(50);

            // Seed Admin
            var adminId = "5f7a2055-3dc9-435e-8b22-b5ad16f97815";
            var adminUser = new MyWikiUser()
            {
                Id = adminId,
                UserName = "admin",
                Email = "admin@mywiki.com",
                Department = "Administration",
                NormalizedUserName = "admin".ToUpper(),
                NormalizedEmail = "admin@mywiki.com".ToUpper()

            };
            adminUser.PasswordHash = new PasswordHasher<MyWikiUser>()
                .HashPassword(adminUser, "admin123");
            builder.Entity<MyWikiUser>().HasData(adminUser);


            // Give Admin both roles - Admin, User
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = adminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
