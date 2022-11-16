using JDBebidasAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDBEBIDASAPI.Model
{
    public class BebidaMap : DbContext
    {
        public BebidaMap(DbContextOptions<BebidaMap> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Bebida> Bebidas { get; set; }

    }
}
