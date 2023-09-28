using Microsoft.AspNetCore.Identity;

namespace WebProgBeadando.Services;

public class RoleSetupService
{
    private static readonly string[] RoleNames = { "Admin" };

    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSetupService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SetupRoles()
    {
        foreach (string roleName in RoleNames)
        {
            bool roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                 await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}