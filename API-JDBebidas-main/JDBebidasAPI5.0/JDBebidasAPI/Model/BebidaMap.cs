using JDBebidasAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace JDBEBIDASAPI.Model
{
    public class BebidaMap : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=senai.123;Persist Security Info=True;User ID=sa;Initial Catalog=JDBebidasAPI;Data Source=.\\SENAI");
        }
        public DbSet<Bebida> Bebidas { get; set; }

    }
}
