using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Models {
    public class PindexContext : DbContext{

        public readonly IConfiguration Configuration;
        public PindexContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseNpgsql(Configuration.GetConnectionString("PindexDb"));
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Canorg> Canorgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Canorg>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Canorgs)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Office>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Offices)
                .HasForeignKey(o => o.OfficeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PindexBackend.Models.Office> Office { get; set; } = default!;
        
    }

}
