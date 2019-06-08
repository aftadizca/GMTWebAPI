using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Material> Materials { set; get; }
        public DbSet<StatusQC> StatusQCs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<MaterialOut> MaterialOuts { get; set; }
        public DbSet<LocationStock> LocationStock { get; set; }
        public DbSet<StokMaterialOut> StokMaterialOut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StokMaterialOut>()
                .HasKey(smo => new { smo.StokID, smo.Id });
            modelBuilder.Entity<StokMaterialOut>()
                .HasOne(smo => smo.MaterialOut)
                .WithMany(mo => mo.StokMaterialOut)
                .HasForeignKey(bc => bc.StokID);
            modelBuilder.Entity<StokMaterialOut>()
                .HasOne(smo => smo.MaterialOut)
                .WithMany(s => s.StokMaterialOut)
                .HasForeignKey(s => s.Id);

        }
    }
}
