

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
                new Category { Id = 5, Name = "Simulation", Description = "Simulation games" },
                new Category { Id = 6, Name = "Racing", Description = "High-speed racing games" },
                new Category { Id = 7, Name = "Survival", Description = "Survival games" },
                new Category { Id = 8, Name = "Puzzle", Description = "Puzzle-solving games" },
                new Category { Id = 9, Name = "Shooter", Description = "First-person and third-person shooters" },
                new Category { Id = 10, Name = "Sports", Description = "Sports games" }
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
                new Game { Id = 10, GameName = "God of War", CategoryId = 2, Description = "An action-adventure game", Price = 49.99M, Discount = 0, Developer = "Santa Monica Studio", PublisherId = 8, CreatedDate = new DateTime(2018, 4, 20), Platform = "PS4" },
                new Game { Id = 11, GameName = "The Legend of Zelda: Breath of the Wild", CategoryId = 2, Description = "An open-world adventure game", Price = 59.99M, Discount = 0, Developer = "Nintendo", PublisherId = 9, CreatedDate = new DateTime(2017, 3, 3), Platform = "Switch" },
                new Game { Id = 12, GameName = "Assassin's Creed Valhalla", CategoryId = 2, Description = "A Viking-themed action RPG", Price = 59.99M, Discount = 10, Developer = "Ubisoft Montreal", PublisherId = 10, CreatedDate = new DateTime(2020, 11, 10), Platform = "PC, PS4, Xbox One" },
                new Game { Id = 13, GameName = "Call of Duty: Modern Warfare", CategoryId = 9, Description = "A first-person shooter", Price = 59.99M, Discount = 20, Developer = "Infinity Ward", PublisherId = 11, CreatedDate = new DateTime(2019, 10, 25), Platform = "PC, PS4, Xbox One" },
                new Game { Id = 14, GameName = "DOOM Eternal", CategoryId = 9, Description = "A fast-paced first-person shooter", Price = 49.99M, Discount = 15, Developer = "id Software", PublisherId = 12, CreatedDate = new DateTime(2020, 3, 20), Platform = "PC, PS4, Xbox One" },
                new Game { Id = 15, GameName = "Final Fantasy VII Remake", CategoryId = 3, Description = "A reimagining of the classic RPG", Price = 59.99M, Discount = 10, Developer = "Square Enix", PublisherId = 13, CreatedDate = new DateTime(2020, 4, 10), Platform = "PS4" },
                new Game { Id = 16, GameName = "Halo Infinite", CategoryId = 9, Description = "A sci-fi first-person shooter", Price = 59.99M, Discount = 5, Developer = "343 Industries", PublisherId = 14, CreatedDate = new DateTime(2021, 12, 8), Platform = "PC, Xbox Series X/S" },
                new Game { Id = 17, GameName = "Half-Life: Alyx", CategoryId = 2, Description = "A VR action-adventure game", Price = 59.99M, Discount = 20, Developer = "Valve", PublisherId = 15, CreatedDate = new DateTime(2020, 3, 23), Platform = "PC" },
                new Game { Id = 18, GameName = "Yakuza: Like a Dragon", CategoryId = 3, Description = "A turn-based RPG", Price = 59.99M, Discount = 10, Developer = "Ryu Ga Gotoku Studio", PublisherId = 16, CreatedDate = new DateTime(2020, 11, 10), Platform = "PC, PS4, Xbox One" },
                new Game { Id = 19, GameName = "Mortal Kombat 11", CategoryId = 1, Description = "A fighting game", Price = 49.99M, Discount = 10, Developer = "NetherRealm Studios", PublisherId = 17, CreatedDate = new DateTime(2019, 4, 23), Platform = "PC, PS4, Xbox One" },
                new Game { Id = 20, GameName = "Resident Evil Village", CategoryId = 7, Description = "A survival horror game", Price = 59.99M, Discount = 15, Developer = "Capcom", PublisherId = 18, CreatedDate = new DateTime(2021, 5, 7), Platform = "PC, PS5, Xbox Series X/S" }
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
                new Publisher { Id = 8, Name = "Sony Interactive Entertainment" },
                new Publisher { Id = 9, Name = "Nintendo" },
                new Publisher { Id = 10, Name = "Ubisoft" },
                new Publisher { Id = 11, Name = "Activision" },
                new Publisher { Id = 12, Name = "Bethesda Softworks" },
                new Publisher { Id = 13, Name = "Square Enix" },
                new Publisher { Id = 14, Name = "Microsoft Studios" },
                new Publisher { Id = 15, Name = "Valve" },
                new Publisher { Id = 16, Name = "SEGA" },
                new Publisher { Id = 17, Name = "Warner Bros. Interactive Entertainment" },
                new Publisher { Id = 18, Name = "Capcom" },
                new Publisher { Id = 19, Name = "Blizzard Entertainment" },
                new Publisher { Id = 20, Name = "Take-Two Interactive" }
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
                new Image { Id = 10, GameId = 10, ImageUrl = "/images/godofwar.jpg", Name = "godofwar", ImageType = "card" },
                new Image { Id = 11, GameId = 11, ImageUrl = "/images/zelda.jpg", Name = "zelda", ImageType = "card" },
                new Image { Id = 12, GameId = 12, ImageUrl = "/images/assassinscreed.jpg", Name = "assassinscreed", ImageType = "card" },
                new Image { Id = 13, GameId = 13, ImageUrl = "/images/cod.jpg", Name = "cod", ImageType = "card" },
                new Image { Id = 14, GameId = 14, ImageUrl = "/images/doom.jpg", Name = "doom", ImageType = "card" },
                new Image { Id = 15, GameId = 15, ImageUrl = "/images/ff7.jpg", Name = "ff7", ImageType = "card" },
                new Image { Id = 16, GameId = 16, ImageUrl = "/images/halo.jpg", Name = "halo", ImageType = "card" },
                new Image { Id = 17, GameId = 17, ImageUrl = "/images/halflife.jpg", Name = "halflife", ImageType = "card" },
                new Image { Id = 18, GameId = 18, ImageUrl = "/images/yakuza.jpg", Name = "yakuza", ImageType = "card" },
                new Image { Id = 19, GameId = 19, ImageUrl = "/images/mk11.jpg", Name = "mk11", ImageType = "card" },
                new Image { Id = 20, GameId = 20, ImageUrl = "/images/residentevil.jpg", Name = "residentevil", ImageType = "card" }
            );
            // Seed data for SystemRequirements
            modelBuilder.Entity<SystemRequirement>().HasData(
                new SystemRequirement { Id = 1, GameId = 2, SystemProcessor = "Intel Core i5-3470", SystemMemory = "8 GB", Storage = "72 GB", Graphics = "NVIDIA GTX 660 2GB", OS = "Windows 10" },
                new SystemRequirement { Id = 2, GameId = 3, SystemProcessor = "Intel Core i7-4790", SystemMemory = "12 GB", Storage = "70 GB", Graphics = "NVIDIA GTX 1060 6GB", OS = "Windows 10" },
                new SystemRequirement { Id = 3, GameId = 4, SystemProcessor = "Intel Core i5-2500K", SystemMemory = "8 GB", Storage = "150 GB", Graphics = "NVIDIA GTX 770 2GB", OS = "Windows 10" },
                new SystemRequirement { Id = 4, GameId = 5, SystemProcessor = "Intel Core i3-3225", SystemMemory = "4 GB", Storage = "12 GB", Graphics = "Intel HD Graphics 4000", OS = "Windows 10" },
                new SystemRequirement { Id = 5, GameId = 6, SystemProcessor = "Intel Core i5-2500", SystemMemory = "8 GB", Storage = "8 GB", Graphics = "AMD Radeon HD 6870", OS = "Windows 7" },
                new SystemRequirement { Id = 6, GameId = 7, SystemProcessor = "Intel Core i3-3210", SystemMemory = "4 GB", Storage = "1 GB", Graphics = "Intel HD Graphics 4000", OS = "Windows 10" },
                new SystemRequirement { Id = 7, GameId = 8, SystemProcessor = "Intel Core i5-7300U", SystemMemory = "8 GB", Storage = "20 GB", Graphics = "Intel HD Graphics 620", OS = "Windows 10" },
                new SystemRequirement { Id = 8, GameId = 9, SystemProcessor = "Intel Core i3-2100", SystemMemory = "2 GB", Storage = "500 MB", Graphics = "Intel HD Graphics 3000", OS = "Windows 7" },
                new SystemRequirement { Id = 9, GameId = 10, SystemProcessor = "Intel Core i7-6700K", SystemMemory = "16 GB", Storage = "100 GB", Graphics = "NVIDIA GTX 1080 8GB", OS = "Windows 10" },
                new SystemRequirement { Id = 10, GameId = 11, SystemProcessor = "Intel i5-9600K", SystemMemory = "8 GB", Storage = "50 GB", Graphics = "NVIDIA GTX 1050 Ti", OS = "Windows 10" },
                new SystemRequirement { Id = 11, GameId = 12, SystemProcessor = "AMD Ryzen 5 3600", SystemMemory = "16 GB", Storage = "60 GB", Graphics = "NVIDIA GTX 1660 Super", OS = "Windows 10" },
                new SystemRequirement { Id = 12, GameId = 13, SystemProcessor = "Intel i7-10700K", SystemMemory = "8 GB", Storage = "40 GB", Graphics = "NVIDIA RTX 2060", OS = "Windows 10" },
                new SystemRequirement { Id = 13, GameId = 14, SystemProcessor = "AMD Ryzen 3 3300X", SystemMemory = "8 GB", Storage = "30 GB", Graphics = "NVIDIA GTX 1060", OS = "Windows 10" },
                new SystemRequirement { Id = 14, GameId = 15, SystemProcessor = "Intel i5-10400F", SystemMemory = "8 GB", Storage = "25 GB", Graphics = "NVIDIA GTX 1050 Ti", OS = "Windows 10" },
                new SystemRequirement { Id = 15, GameId = 16, SystemProcessor = "Intel i7-9700K", SystemMemory = "16 GB", Storage = "80 GB", Graphics = "NVIDIA RTX 2070 Super", OS = "Windows 10" },
                new SystemRequirement { Id = 16, GameId = 17, SystemProcessor = "AMD Ryzen 5 2600", SystemMemory = "8 GB", Storage = "45 GB", Graphics = "NVIDIA GTX 1650", OS = "Windows 10" },
                new SystemRequirement { Id = 17, GameId = 18, SystemProcessor = "Intel i5-9400F", SystemMemory = "8 GB", Storage = "35 GB", Graphics = "NVIDIA GTX 1050", OS = "Windows 10" },
                new SystemRequirement { Id = 18, GameId = 19, SystemProcessor = "Intel i3-8100", SystemMemory = "4 GB", Storage = "20 GB", Graphics = "Intel UHD Graphics 630", OS = "Windows 10" },
                new SystemRequirement { Id = 19, GameId = 20, SystemProcessor = "AMD Ryzen 5 3600X", SystemMemory = "16 GB", Storage = "50 GB", Graphics = "NVIDIA RTX 2060 Super", OS = "Windows 10" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
