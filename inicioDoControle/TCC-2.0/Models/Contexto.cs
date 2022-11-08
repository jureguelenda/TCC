using Microsoft.EntityFrameworkCore;

namespace TCC_2._0.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<ENTRADA> ENTRADA { get; set; }
    }
}
