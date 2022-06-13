using AllUp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Photo> Photos { get; set; }


    }
}
