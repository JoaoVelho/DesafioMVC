﻿using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
