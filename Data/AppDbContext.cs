using Microsoft.EntityFrameworkCore;
using PerpusWebProject.Models;

namespace PerpusWebProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Buku> Bukus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Peminjaman> Peminjamans { get; set; }
    }
}