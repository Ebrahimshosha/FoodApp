namespace FoodApp.Api.VerticalSlicing.Data.Context;

public static class StoreContextseed
{
    public static async Task seedAsync(ApplicationDBContext dbcontext)
    {
        Role? adminRole = null;

        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Admin))
        {
            adminRole = new Role
            {
                Name = DefaultRoles.Admin
            };

            await dbcontext.Set<Role>().AddAsync(adminRole);
            await dbcontext.SaveChangesAsync();
        }
        else
        {
            adminRole = await dbcontext.Set<Role>().FirstOrDefaultAsync(r => r.Name == DefaultRoles.Admin);
        }

        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Customer))
        {
           var CustomerRole = new Role
            {
                Name = DefaultRoles.Customer,
                IsDefault = true
            };

            await dbcontext.Set<Role>().AddAsync(CustomerRole);
            await dbcontext.SaveChangesAsync();
        }
        
        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Manager))
        {
            var ManagerRole = new Role
            {
                Name = DefaultRoles.Manager,
                IsDefault = true
            };

            await dbcontext.Set<Role>().AddAsync(ManagerRole);
            await dbcontext.SaveChangesAsync();
        }
        
        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Chef))
        {
            var ChefRole = new Role
            {
                Name = DefaultRoles.Chef,
                IsDefault = true
            };

            await dbcontext.Set<Role>().AddAsync(ChefRole);
            await dbcontext.SaveChangesAsync();
        }
        

        if (!dbcontext.Set<User>().Any(u => u.UserName == DefaultUsers.AdminUserName))
        {
            var user = new User
            {
                Country = DefaultUsers.Country,
                Email = DefaultUsers.AdminEmail,
                UserName = DefaultUsers.AdminUserName,
                IsEmailVerified = true,
                PhoneNumber = DefaultUsers.AdminPhoneNumber,
                VerificationOTP = null,
                PasswordHash = PasswordHasher.HashPassword(DefaultUsers.AdminPassword)
            };

            await dbcontext.Set<User>().AddAsync(user);
            await dbcontext.SaveChangesAsync();

            if (adminRole != null)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = adminRole.Id,
                };

                await dbcontext.UserRoles.AddAsync(userRole);
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}