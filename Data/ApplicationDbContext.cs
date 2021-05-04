using System;
using System.Collections.Generic;
using System.Text;
using DesafioMVC.Configuration;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<State> States { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Property>()
                .Property<string>("_images").HasColumnName("Images");

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BusinessConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new DistrictConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new AdminClaimConfiguration());
        }
    }
}
