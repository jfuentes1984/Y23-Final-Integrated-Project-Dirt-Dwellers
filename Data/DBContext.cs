#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Y23_DirtDwellers.Models;

public class DBContext : IdentityDbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public DbSet<Y23_DirtDwellers.Models.Product> Products { get; set; }

    public DbSet<Y23_DirtDwellers.Models.Plant> Plants { get; set; }

    public DbSet<Y23_DirtDwellers.Models.SiteUser> SiteUser { get; set; }
}
