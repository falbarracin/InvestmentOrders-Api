using InvestmentOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentOrders.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<AssetType> AssetTypes => Set<AssetType>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ORDER
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.AccountId).IsRequired();
                entity.Property(o => o.AssetId).IsRequired();
                entity.Property(o => o.Quantity).IsRequired();

                entity.Property(o => o.Price)
                      .HasPrecision(18, 4);

                entity.Property(o => o.TotalAmount)
                      .HasPrecision(18, 4)
                      .IsRequired();

                entity.HasOne(o => o.Asset)
                      .WithMany()
                      .HasForeignKey(o => o.AssetId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Status)
                      .WithMany()
                      .HasForeignKey(o => o.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ASSET
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Ticker)
                      .HasMaxLength(32)
                      .IsRequired();

                entity.Property(a => a.Name)
                      .HasMaxLength(64)
                      .IsRequired();

                entity.Property(a => a.Price)
                      .HasPrecision(18, 4)
                      .IsRequired();

                entity.HasOne(a => a.AssetType)
                      .WithMany()
                      .HasForeignKey(a => a.AssetTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ORDER STATUS (MASTER)
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Description)
                      .HasMaxLength(32)
                      .IsRequired();
            });

            // ASSET TYPE (MASTER)
            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Description)
                      .HasMaxLength(32)
                      .IsRequired();
            });

            //Insercion
            modelBuilder.Entity<AssetType>().HasData(
               new AssetType { Id = 1, Description = "Acción" },
               new AssetType { Id = 2, Description = "Bono" },
               new AssetType { Id = 3, Description = "FCI" }
           );

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Description = "En proceso" },
                new OrderStatus { Id = 2, Description = "Ejecutada" },
                new OrderStatus { Id = 3, Description = "Cancelada" }
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, Ticker = "AAPL", Name = "Apple", AssetTypeId = 1, Price = 177.97m },
                new Asset { Id = 2, Ticker = "GOOGL", Name = "Alphabet Inc", AssetTypeId = 1, Price = 138.21m },
                new Asset { Id = 3, Ticker = "MSFT", Name = "Microsoft", AssetTypeId = 1, Price = 329.04m },
                new Asset { Id = 4, Ticker = "KO", Name = "Coca Cola", AssetTypeId = 1, Price = 58.30m },
                new Asset { Id = 5, Ticker = "WMT", Name = "Walmart", AssetTypeId = 1, Price = 163.42m },

                new Asset { Id = 6, Ticker = "AL30", Name = "BONOS ARGENTINA USD 2030 L.A", AssetTypeId = 2, Price = 307.40m },
                new Asset { Id = 7, Ticker = "GD30", Name = "Bonos Globales Argentina USD Step Up 2030", AssetTypeId = 2, Price = 336.10m },

                new Asset { Id = 8, Ticker = "Delta.Pesos", Name = "Delta Pesos Clase A", AssetTypeId = 3, Price = 0.0181m },
                new Asset { Id = 9, Ticker = "Fima.Premium", Name = "Fima Premium Clase A", AssetTypeId = 3, Price = 0.0317m }
            );
        }
    }
}
