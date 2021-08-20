
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class UygulamaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Uygulama;Persist Security Info=true");
        }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Kullanici_Rol> Kullanici_Rol { get; set; }
        public DbSet<Rol> Rol { get; set; }

    }
}

