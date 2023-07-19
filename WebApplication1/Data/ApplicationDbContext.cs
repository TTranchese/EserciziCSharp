using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Prodotto> Prodotti { get; set; }
    public DbSet<Ordine> Ordini { get; set; }
    public enum Roles { Admin, User}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
    }
	 public static async Task EnsureSeed(
                IConfiguration conf, 
                UserManager<IdentityUser> userManager, 
                RoleManager<IdentityRole> roleManager
                )
            {
    
                //Se non esistono gli ruoli nel db, li creo
                foreach (Roles role in Enum.GetValues<Roles>())
                {
                    //Cerco lo ruolo corrente
                    if (await roleManager.FindByNameAsync(role.ToString()) == null)
                    {
                        // se non c'è lo creo..
                        var r = new IdentityRole()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = role.ToString(),
                            NormalizedName = role.ToString()
                        };
                        await roleManager.CreateAsync(r);
                    }
                }
                //Recupero admin user e sua password
                string AdminUser = conf.GetValue<string>("Settings:AdminUser");
                string AdminPwd = conf.GetValue<string>("Settings:AdminPassword");
    
                //Controllo se esiste già l'admin
                if (await userManager.FindByEmailAsync(AdminUser) == null)
                {
                    // lo creo..
                    var u = new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = AdminUser,
                        Email = AdminUser,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };
                    try
                    {
                        await userManager.CreateAsync(u, AdminPwd);
                        await userManager.AddToRoleAsync(u, Roles.Admin.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
	
}