﻿using System;
using System.Collections.Generic;
using System.Text;
using FinalProject322.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject322.Data
{
    public class ApplicationDbContext : IdentityDbContext<Userr>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Kupon> Kupon { get; set; }

        public DbSet<Userr> Userr{ get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }







    }
}
