using Lumia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lumia.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Crud> Cruds { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<WhatWeDo> WhatWeDos { get; set; }
  
    }
}



























