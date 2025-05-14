using FarmProductPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FarmProductPortal.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Farmer", "Employee" };

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // === Seed Default Farmer ===
            string farmerEmail = "farmer1@example.com";
            string farmerPassword = "Farmer123!";

            var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
            if (farmerUser == null)
            {
                var newFarmer = new ApplicationUser
                {
                    UserName = farmerEmail,
                    Email = farmerEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newFarmer, farmerPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newFarmer, "Farmer");
                }
            }

            // === Optional: Seed Default Employee ===
            string employeeEmail = "employee1@example.com";
            string employeePassword = "Employee123!";

            var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
            if (employeeUser == null)
            {
                var newEmployee = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newEmployee, employeePassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newEmployee, "Employee");
                }
            }
        }
    }
}
