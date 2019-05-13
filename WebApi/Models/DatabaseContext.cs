using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Material> Materials { set; get; }
        public DbSet<StatusQC> StatusQCs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<MaterialOut> MaterialOuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StokMaterialOut>()
                .HasKey(smo => new { smo.MaterialOutID, smo.StockID });
            modelBuilder.Entity<StokMaterialOut>()
                .HasOne(smo => smo.MaterialOut)
                .WithMany(mo => mo.StokMaterialOut)
                .HasForeignKey(bc => bc.MaterialOutID);
            modelBuilder.Entity<StokMaterialOut>()
                .HasOne(smo => smo.MaterialOut)
                .WithMany(s => s.StokMaterialOut)
                .HasForeignKey(s => s.StockID);

        }

        public DbSet<WebApi.Models.LocationStock> LocationStock { get; set; }
    }
}
