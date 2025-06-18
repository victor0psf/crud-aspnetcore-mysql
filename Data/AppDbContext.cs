using Microsoft.EntityFrameworkCore;
using CrudVF.Models;

namespace CrudVF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Personagem> PB { get; set; }
    }
}