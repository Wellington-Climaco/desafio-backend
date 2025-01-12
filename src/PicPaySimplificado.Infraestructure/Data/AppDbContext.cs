using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Core.Entities;
using System.Reflection;

namespace PicPaySimplificado.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Transference> Transferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);     
        }
    }
}
