using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles (User , Admin , SuperAdmin)
            var adminRoleId = "4214102e-1082-4bba-b677-3c1c14e73c09";
            var superadminRoleId = "f863e507-f25b-4ef1-8582-e01e3a64d036";
            var userRoleId = "6f22ee78-5297-46dc-95cc-44abc9521c9a";
           
            var role = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp  = adminRoleId,

                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superadminRoleId,
                    ConcurrencyStamp  = superadminRoleId,

                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp= userRoleId,
                }


            };
            builder.Entity<IdentityRole>().HasData(role);

            //Seed SuperAdminUser
            var superAdminId = "4c22eb3b-e65f-4ee5-addc-867d4f0bd3a0";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin".ToUpper(),
                Id = superAdminId,
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin@007");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add all role to super admin user
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = superAdminId,
                    RoleId = adminRoleId,
                },

                new IdentityUserRole<string>
                {
                    UserId = superAdminId,
                    RoleId = superadminRoleId,
                },

                new IdentityUserRole<string>
                {
                    UserId = superAdminId,
                    RoleId = userRoleId,
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }

}
