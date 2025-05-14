using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FarmProductPortal.Models;
namespace FarmProductPortal.Data { 

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // or IdentityUser
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Product> Products { get; set; }
}
}