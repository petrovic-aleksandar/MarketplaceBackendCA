using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Persistence
{
    public class MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : DbContext(options)
    {
        public DbSet<Item> Item => Set<Item>();
        public DbSet<Image> Image => Set<Image>();
        public DbSet<ItemType> ItemType => Set<ItemType>();
        public DbSet<User> User => Set<User>();

        public DbSet<Transfer> Transfer => Set<Transfer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            User u1 = new()
            {
                Id = 1,
                Username = "admin",
                Password = "eUS8Chai2BphVYD54jXg24iRP80n2XLBCf5klkgVNGSYr5xCvG05DnHPTRGBxK2q",
                Salt = "eUS8Chai2BphVYD54jXg2w==",
                Name = "John Doe",
                Email = "aa@gmail.com",
                Phone = "67 407648",
                Balance = 0.0,
                Role = UserRole.Admin,
                IsActive = true
            };

            User u2 = new()
            {
                Id = 2,
                Username = "peter",
                Password = "qwbR24euiRkhKRT2Rm5l9DCbmk/euQ460gB8D4N0tZGXhfdfSiaR+VT5STBp2hI9",
                Salt = "qwbR24euiRkhKRT2Rm5l9A==",
                Name = "Peter Petrovich",
                Email = "pp@gmail.com",
                Phone = "+382 67 111 222",
                Balance = 0.0,
                Role = UserRole.User,
                IsActive = true
            };

            User u3 = new()
            {
                Id = 3,
                Username = "rich",
                Password = "eUS8Chai2BphVYD54jXg24iRP80n2XLBCf5klkgVNGSYr5xCvG05DnHPTRGBxK2q",
                Salt = "eUS8Chai2BphVYD54jXg2w==",
                Name = "Guy Rich",
                Email = "gr@gmail.com",
                Phone = "+382 67 101 909",
                Balance = 1000000.0,
                Role = UserRole.User,
                IsActive = true
            };

            User[] users = { u1, u2, u3 };

            modelBuilder.Entity<User>().HasData(users);

            ItemType it1 = new()
            {
                Id = 1,
                Name = "Cars&Vehicles",
                Description = "Cars and other transportation. Scooters, bikes, trains, boats, yachts, airships..",
                ImagePath = "Categories/1.jpg"
            };

            ItemType it2 = new()
            {
                Id = 2,
                Name = "Home&Kitchen",
                Description = "Everything for your home, small home and kitchen electronics.",
                ImagePath = "Categories/2.jpg"
            };

            ItemType it3 = new()
            {
                Id = 3,
                Name = "Electronics",
                Description = "All kinds of devices. Gaming equipment, laptops, home appliances etc.",
                ImagePath = "Categories/3.jpg"
            };

            ItemType it4 = new()
            {
                Id = 4,
                Name = "Sports&Outdoors",
                Description = "Sports clothing and sport requisits",
                ImagePath = "Categories/4.jpg"
            };

            ItemType it5 = new()
            {
                Id = 5,
                Name = "Women's clothing",
                Description = "Everything for women.",
                ImagePath = "Categories/5.jpg"
            };

            ItemType it6 = new()
            {
                Id = 6,
                Name = "Jewelry&Accesories",
                Description = "All kinds of jewelry and decorative items.",
                ImagePath = "Categories/6.jpg"
            };

            ItemType it7 = new()
            {
                Id = 7,
                Name = "Mens's clothing",
                Description = "Clothing items for men.",
                ImagePath = "Categories/7.jpg"
            };

            ItemType it8 = new()
            {
                Id = 8,
                Name = "Books&Media",
                Description = "Books and stuff.",
                ImagePath = "Categories/8.jpg"
            };

            ItemType it9 = new()
            {
                Id = 9,
                Name = "Services",
                Description = "For various intelectual or physical services.",
                ImagePath = "Categories/9.jpg"
            };

            ItemType it10 = new()
            {
                Id = 10,
                Name = "Other",
                Description = "Whatever else.",
                ImagePath = "Categories/10.jpg"
            };

            ItemType[] itemTypes = { it1, it2, it3, it4, it5, it6, it7, it8, it9, it10 };

            modelBuilder.Entity<ItemType>().HasData(itemTypes);

            modelBuilder.Entity<Item>().HasData(
                new {
                    Id = 1,
                    Name = "Audi A4",
                    Description = "Red color, 2021., 35 TFSI",
                    Price = 35000.0,
                    IsActive = true,
                    IsDeleted = false,
                    Createtime = new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972),
                    SellerId = u2.Id,
                    TypeId = it1.Id
                },
                new
                {
                    Id = 2,
                    Name = "Audi A5",
                    Description = "A5 new model, 2021., 40 TFSI",
                    Price = 45000.0,
                    IsActive = true,
                    IsDeleted = false,
                    Createtime = new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972),
                    SellerId = u2.Id,
                    TypeId = it1.Id
                },
                new
                {
                    Id = 3,
                    Name = "Audi Q5",
                    Description = "SUV model, 2021., 45 TFSI",
                    Price = 65000.0,
                    IsActive = true,
                    IsDeleted = false,
                    Createtime = new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972),
                    SellerId = u2.Id,
                    TypeId = it1.Id
                },
                new
                {
                    Id = 4,
                    Name = "Audi TT",
                    Description = "Classic audi, 2016., 3.0 gasoline",
                    Price = 15000.0,
                    IsActive = true,
                    IsDeleted = false,
                    Createtime = new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972),
                    SellerId = u2.Id,
                    TypeId = it1.Id
                },
                new
                {
                    Id = 5,
                    Name = "Lotus Elise",
                    Description = "Yellow color, 2014., 35 TFSI",
                    Price = 30000.0,
                    IsActive = true,
                    IsDeleted = false,
                    Createtime = new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972),
                    SellerId = u2.Id,
                    TypeId = it1.Id
                }
                );

            modelBuilder.Entity<Image>().HasData(
                new
                {
                    Id = 1,
                    ItemId = 1,
                    Path = "audi_a4.jpg",
                    IsFront = true
                },
                new
                {
                    Id = 2,
                    ItemId = 1,
                    Path = "audi_a4_2.jpg",
                    IsFront = false
                },
                new
                {
                    Id = 3,
                    ItemId = 1,
                    Path = "audi_a4_3.jpg",
                    IsFront = false
                },
                new
                {
                    Id = 4,
                    ItemId = 2,
                    Path = "audi_a5.jpg",
                    IsFront = true
                },
                new
                {
                    Id = 5,
                    ItemId = 3,
                    Path = "audi_q5.jpg",
                    IsFront = true
                },
                new
                {
                    Id = 6,
                    ItemId = 4,
                    Path = "audi_tt.jpg",
                    IsFront = true
                },
                new
                {
                    Id = 7,
                    ItemId = 5,
                    Path = "lotuselise.jpg",
                    IsFront = true
                }
                );
                
        }

    }
}
