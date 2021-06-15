using Microsoft.EntityFrameworkCore;

namespace PC04.Models
{
    public class FotoContext : DbContext
    {
        public DbSet<Foto> Fotos { get; set; }
        public FotoContext(DbContextOptions dco) : base(dco) {

        }
    }
}