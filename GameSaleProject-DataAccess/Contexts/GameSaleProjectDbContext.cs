

using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_DataAccess.Contexts
{
    public class GameSaleProjectDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public GameSaleProjectDbContext(DbContextOptions<GameSaleProjectDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameSale> GameSales { get; set; }
        public DbSet<GameSaleDetail> GameSaleDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SystemRequirement> SystemRequirements { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AspNetUsers"); // Ensuring it maps to AspNetUsers
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.ProfilePictureUrl)
                      .HasMaxLength(200)
                      .HasDefaultValue("/images/DefaultPfp.jpg");
            });


            modelBuilder.Entity<Publisher>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict); ;



            modelBuilder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PublisherId);



            modelBuilder.Entity<Game>()
            .Property(g => g.Price)
            .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<GameSale>()
                .Property(gs => gs.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<GameSaleDetail>()
                .Property(gsd => gsd.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Game>().Property(g => g.GameName).HasMaxLength(100);
            modelBuilder.Entity<Category>().Property(g => g.Name).HasMaxLength(100);

            modelBuilder.Entity<Game>()
            .HasMany(g => g.Images)
            .WithOne(i => i.Game)
            .HasForeignKey(i => i.GameId);

            modelBuilder.Entity<Game>()
        .HasOne(g => g.SystemRequirement)
        .WithOne(sr => sr.Game)
        .HasForeignKey<SystemRequirement>(sr => sr.GameId);


            modelBuilder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PublisherId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CategoryId);

            modelBuilder.Entity<GameSale>()
                .HasOne(gs => gs.User)
                .WithMany(c => c.GameSales)
                .HasForeignKey(gs => gs.UserId);

            modelBuilder.Entity<GameSaleDetail>()
                .HasOne(gsd => gsd.GameSale)
                .WithMany(gs => gs.GameSaleDetails)
                .HasForeignKey(gsd => gsd.GameSaleId);

            modelBuilder.Entity<GameSaleDetail>()
                .HasOne(gsd => gsd.Game)
                .WithMany()
                .HasForeignKey(gsd => gsd.GameId);

            // Seed data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Description = "Action games" },
                new Category { Id = 2, Name = "Adventure", Description = "Adventure games" },
                new Category { Id = 3, Name = "RPG", Description = "Role-playing games" },
                new Category { Id = 4, Name = "Strategy", Description = "Strategy games" },
                new Category { Id = 5, Name = "Simulation", Description = "Simulation games" }
            );



            // Seed data for Game
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, GameName = "The Witcher 3: Wild Hunt", CategoryId = 3, Description = "An open-world RPG game", Price = 39.99M, Discount = 0, Developer = "CD Projekt Red", PublisherId = 1, CreatedDate = new DateTime(2015, 5, 19), Platform = "PC" },
                new Game { Id = 2, GameName = "Grand Theft Auto V", CategoryId = 1, Description = "An action-adventure game", Price = 29.99M, Discount = 20, Developer = "Rockstar North", PublisherId = 2, CreatedDate = new DateTime(2013, 9, 17), Platform = "PC" },
                new Game { Id = 3, GameName = "Cyberpunk 2077", CategoryId = 3, Description = "A futuristic RPG game", Price = 59.99M, Discount = 10, Developer = "CD Projekt Red", PublisherId = 1, CreatedDate = new DateTime(2020, 12, 10), Platform = "PC" },
                new Game { Id = 4, GameName = "Red Dead Redemption 2", CategoryId = 2, Description = "An open-world adventure game", Price = 49.99M, Discount = 0, Developer = "Rockstar Studios", PublisherId = 2, CreatedDate = new DateTime(2018, 10, 26), Platform = "PC" },
                new Game { Id = 5, GameName = "Civilization VI", CategoryId = 4, Description = "A strategy game", Price = 39.99M, Discount = 0, Developer = "Firaxis Games", PublisherId = 3, CreatedDate = new DateTime(2016, 10, 21), Platform = "PC" },
                new Game { Id = 6, GameName = "The Sims 4", CategoryId = 5, Description = "A life simulation game", Price = 49.99M, Discount = 0, Developer = "Maxis", PublisherId = 4, CreatedDate = new DateTime(2014, 9, 2), Platform = "PC" },
                new Game { Id = 7, GameName = "Dark Souls III", CategoryId = 3, Description = "An action RPG game", Price = 59.99M, Discount = 0, Developer = "FromSoftware", PublisherId = 5, CreatedDate = new DateTime(2016, 4, 12), Platform = "PC" },
                new Game { Id = 8, GameName = "Minecraft", CategoryId = 5, Description = "A sandbox game", Price = 26.95M, Discount = 0, Developer = "Mojang", PublisherId = 6, CreatedDate = new DateTime(2011, 11, 18), Platform = "PC" },
                new Game { Id = 9, GameName = "Fortnite", CategoryId = 1, Description = "A battle royale game", Price = 0M, Discount = 0, Developer = "Epic Games", PublisherId = 7, CreatedDate = new DateTime(2017, 7, 21), Platform = "PC" },
                new Game { Id = 10, GameName = "Stardew Valley", CategoryId = 2, Description = "A farming simulation game", Price = 14.99M, Discount = 0, Developer = "ConcernedApe", PublisherId = 8, CreatedDate = new DateTime(2016, 2, 26), Platform = "PC" }
            );

            // Seed data for Publisher
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "CD Projekt" },
                new Publisher { Id = 2, Name = "Rockstar Games" },
                new Publisher { Id = 3, Name = "2K Games" },
                new Publisher { Id = 4, Name = "Electronic Arts" },
                new Publisher { Id = 5, Name = "Bandai Namco Entertainment" },
                new Publisher { Id = 6, Name = "Mojang" },
                new Publisher { Id = 7, Name = "Epic Games" },
                new Publisher { Id = 8, Name = "ConcernedApe" }
            );

            // Seed data for Image
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, GameId = 1, ImageUrl = "/images/witcher3.jpg", Name = "witcher3", ImageType = "card" },
                new Image { Id = 2, GameId = 2, ImageUrl = "/images/gtav.jpg", Name = "gtav", ImageType = "card" },
                new Image { Id = 3, GameId = 3, ImageUrl = "/images/cyberpunk2077.jpg", Name = "cyberpunk2077" },
                new Image { Id = 4, GameId = 4, ImageUrl = "/images/rdr2.jpg", Name = "rdr2", ImageType = "card" },
                new Image { Id = 5, GameId = 5, ImageUrl = "/images/civ6.jpg", Name = "civ6", ImageType = "card" },
                new Image { Id = 6, GameId = 6, ImageUrl = "/images/sims4.jpg", Name = "sims4", ImageType = "card" },
                new Image { Id = 7, GameId = 7, ImageUrl = "/images/darksouls3.jpg", Name = "darksouls3", ImageType = "card" },
                new Image { Id = 8, GameId = 8, ImageUrl = "/images/minecraft.jpg", Name = "minecraft", ImageType = "card" },
                new Image { Id = 9, GameId = 9, ImageUrl = "/images/fortnite.jpg", Name = "fortnite", ImageType = "card" },
                new Image { Id = 10, GameId = 10, ImageUrl = "/images/stardewvalley.jpg", Name = "stardewvalley", ImageType = "card" },
                new Image { Id = 11, GameId = 7, ImageUrl = "/images/darksouls3Caus.jpg", Name = "darksouls3Caus", ImageType = "carousel" },
                new Image { Id = 12, GameId = 4, ImageUrl = "/images/rdr2Caus.jpg", Name = "rdr2Caus", ImageType = "carousel" },
                new Image { Id = 13, GameId = 9, ImageUrl = "/images/fortniteCaus.jpg", Name = "fortniteCaus", ImageType = "carousel" }
            );
            modelBuilder.Entity<SystemRequirement>().HasData(
        new SystemRequirement
        {
            Id = 1,
            SystemProcessor = "Intel Core i5-3470",
            SystemMemory = "8 GB",
            Storage = "72 GB",
            Graphics = "NVIDIA GTX 660 2GB",
            OS = "Windows 10",
            GameId = 2,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 2,
            SystemProcessor = "Intel Core i7-4790",
            SystemMemory = "12 GB",
            Storage = "70 GB",
            Graphics = "NVIDIA GTX 1060 6GB",
            OS = "Windows 10",
            GameId = 3,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 3,
            SystemProcessor = "Intel Core i5-2500K",
            SystemMemory = "8 GB",
            Storage = "150 GB",
            Graphics = "NVIDIA GTX 770 2GB",
            OS = "Windows 10",
            GameId = 4,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 4,
            SystemProcessor = "Intel Core i3-3225",
            SystemMemory = "4 GB",
            Storage = "12 GB",
            Graphics = "Intel HD Graphics 4000",
            OS = "Windows 10",
            GameId = 5,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 5,
            SystemProcessor = "Intel Core i5-2500",
            SystemMemory = "8 GB",
            Storage = "8 GB",
            Graphics = "AMD Radeon HD 6870",
            OS = "Windows 7",
            GameId = 6,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 6,
            SystemProcessor = "Intel Core i3-3210",
            SystemMemory = "4 GB",
            Storage = "1 GB",
            Graphics = "Intel HD Graphics 4000",
            OS = "Windows 10",
            GameId = 7,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 7,
            SystemProcessor = "Intel Core i5-7300U",
            SystemMemory = "8 GB",
            Storage = "20 GB",
            Graphics = "Intel HD Graphics 620",
            OS = "Windows 10",
            GameId = 8,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 8,
            SystemProcessor = "Intel Core i3-2100",
            SystemMemory = "2 GB",
            Storage = "500 MB",
            Graphics = "Intel HD Graphics 3000",
            OS = "Windows 7",
            GameId = 9,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new SystemRequirement
        {
            Id = 9,
            SystemProcessor = "Intel Core i7-6700K",
            SystemMemory = "16 GB",
            Storage = "100 GB",
            Graphics = "NVIDIA GTX 1080 8GB",
            OS = "Windows 10",
            GameId = 10,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        }
    );
            base.OnModelCreating(modelBuilder);
        }
    }
}
