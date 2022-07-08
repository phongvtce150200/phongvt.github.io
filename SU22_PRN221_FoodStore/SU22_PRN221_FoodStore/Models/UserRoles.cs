using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SU22_PRN221_FoodStore.Models
{
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string Staff = "Staff";
        public const string Customer = "Customer";
        public static async Task CreateRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create all Role for System
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.Staff))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Staff));

            if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

        }
    }
}
