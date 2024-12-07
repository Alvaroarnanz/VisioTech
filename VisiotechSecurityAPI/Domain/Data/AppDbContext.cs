using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VisiotechSecurityAPI.Domain.Entity;

namespace VisiotechSecurityAPI.Domain.Data
{
    // context para conectar con la base de datos
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     
        // Declaramos las diferentes entidades 
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }
        public DbSet<Grape> Grapes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary keys
            modelBuilder.Entity<Manager>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Parcel>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Vineyard>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Grape>()
                .HasKey(i => i.Id);


            //Foreign keys
            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.Manager)
                .WithMany(m => m.Parcels)
                .HasForeignKey(p => p.ManagerId);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.Vineyard)
                .WithMany(v => v.Parcels)
                .HasForeignKey(p => p.VineyardId);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.Grape)
                .WithMany(g => g.Parcels)
                .HasForeignKey(p => p.GrapeId);
        }

    }
}
