using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Initializer
{
    public static class Seeder
    {                           //треба Microsoft.AspNetCore.Http.Abstractions
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //для юзера
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUserEntity>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRoleEntity>>();

            await context.Database.MigrateAsync();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new AppRoleEntity { Name = "admin" });
                await roleManager.CreateAsync(new AppRoleEntity { Name = "user" });
            }

            // ---------- USERS ----------
            if (!userManager.Users.Any())
            {
                var admin = new AppUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    FirstName = "John",
                    Surname = "Doe",
                    Email = "admin@mail.com",
                    Address = "Rivne, Soborna St. 1",
                    Age = 35
                };
                var buyer1 = new AppUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user",
                    FirstName = "Ivan",
                    Surname = "Fedorov",
                    Email = "user@mail.com",
                    Address = "Kyiv, Khreshchatyk St. 10",
                    Age = 27
                };
                var seller1 = new AppUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "olena_seller",
                    FirstName = "Olena",
                    Surname = "Petrenko",
                    Email = "olena@mail.com",
                    Address = "Lviv, Svobody Ave. 5",
                    Age = 31
                };
                var seller2 = new AppUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "taras_seller",
                    FirstName = "Taras",
                    Surname = "Kovalenko",
                    Email = "taras@mail.com",
                    Address = "Odesa, Deribasivska St. 12",
                    Age = 42
                };
                var buyer2 = new AppUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "sofia_buyer",
                    FirstName = "Sofia",
                    Surname = "Kravchuk",
                    Email = "sofia@mail.com",
                    Address = "Dnipro, Yavornytskoho Ave. 8",
                    Age = 24
                };

                await userManager.CreateAsync(admin, "qwerty");
                await userManager.CreateAsync(buyer1, "qwerty");
                await userManager.CreateAsync(seller1, "qwerty");
                await userManager.CreateAsync(seller2, "qwerty");
                await userManager.CreateAsync(buyer2, "qwerty");

                await userManager.AddToRoleAsync(admin, "admin");
                await userManager.AddToRoleAsync(buyer1, "user");
                await userManager.AddToRoleAsync(seller1, "user");
                await userManager.AddToRoleAsync(seller2, "user");
                await userManager.AddToRoleAsync(buyer2, "user");
            }

            // ---------- CATEGORIES ----------
            if (!context.ItemCategories.Any())
            {
                var categories = new List<ItemCategoryEntity>
                {
                    new ItemCategoryEntity
                    {
                        Name = "Електроніка",
                        Image = "/images/categories/electronics.jpg"
                    },
                    new ItemCategoryEntity
                    {
                        Name = "Меблі",
                        Image = "/images/categories/furniture.jpg"
                    },
                    new ItemCategoryEntity
                    {
                        Name = "Одяг та взуття",
                        Image = "/images/categories/clothing.jpg"
                    }
                };

                await context.ItemCategories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // ---------- ITEMS ----------
            if (!context.Items.Any())
            {
                var seller1 = await userManager.FindByNameAsync("olena_seller");
                var seller2 = await userManager.FindByNameAsync("taras_seller");

                var electronics = await context.ItemCategories.FirstAsync(c => c.Name == "Електроніка");
                var furniture = await context.ItemCategories.FirstAsync(c => c.Name == "Меблі");
                var clothing = await context.ItemCategories.FirstAsync(c => c.Name == "Одяг та взуття");

                var items = new List<ItemEntity>
                {
                    new ItemEntity
                    {
                        Name = "iPhone 13 Pro 256GB",
                        Description = "Стан як новий, батарея 92%, комплект повний.",
                        //Image = "storage/"
                        Price = 24500m,
                        Quantity = 1,
                        IsUsed = true,
                        IsSoldOut = true,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(15),
                        SellerId = seller1.Id,
                        CategoryId = electronics.Id
                    },
                    new ItemEntity
                    {
                        Name = "Ноутбук Lenovo IdeaPad 3",
                        Description = "Ryzen 5, 8GB RAM, SSD 512GB. Для навчання й офісних задач.",
                        Price = 18900m,
                        Quantity = 3,
                        IsUsed = false,
                        IsSoldOut = false,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(30),
                        SellerId = seller1.Id,
                        CategoryId = electronics.Id
                    },
                    new ItemEntity
                    {
                        Name = "Навушники Sony WH-1000XM4",
                        Description = "Шумозаглушення, оригінал, коробка та чохол в комплекті.",
                        Price = 6200m,
                        Quantity = 2,
                        IsUsed = true,
                        IsSoldOut = false,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(20),
                        SellerId = seller2.Id,
                        CategoryId = electronics.Id
                    },
                    new ItemEntity
                    {
                        Name = "Диван кутовий IKEA",
                        Description = "Розкладний, тканина знімна, пранню піддається.",
                        Price = 9800m,
                        Quantity = 1,
                        IsUsed = true,
                        IsSoldOut = true,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(10),
                        SellerId = seller2.Id,
                        CategoryId = furniture.Id
                    },
                    new ItemEntity
                    {
                        Name = "Письмовий стіл дерев'яний",
                        Description = "Масив дуба, 120x60 см, дві шухляди.",
                        Price = 3400m,
                        Quantity = 4,
                        IsUsed = false,
                        IsSoldOut = false,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(30),
                        SellerId = seller1.Id,
                        CategoryId = furniture.Id
                    },
                    new ItemEntity
                    {
                        Name = "Зимова куртка The North Face",
                        Description = "Розмір L, мембрана, носилась один сезон.",
                        Price = 2800m,
                        Quantity = 1,
                        IsUsed = true,
                        IsSoldOut = false,
                        ListingExpiryDate = DateTime.UtcNow.AddDays(25),
                        SellerId = seller2.Id,
                        CategoryId = clothing.Id
                    }
                };

                await context.Items.AddRangeAsync(items);
                await context.SaveChangesAsync();
            }

            // ---------- ORDERS ----------
            if (!context.Orders.Any())
            {
                var buyer1 = await userManager.FindByNameAsync("user");
                var buyer2 = await userManager.FindByNameAsync("sofia_buyer");
                var seller1 = await userManager.FindByNameAsync("olena_seller");
                var seller2 = await userManager.FindByNameAsync("taras_seller");

                var iphone = await context.Items.FirstAsync(i => i.Name.Contains("iPhone"));
                var sofa = await context.Items.FirstAsync(i => i.Name.Contains("Диван"));

                var orders = new List<OrderEntity>
                {
                    new OrderEntity
                    {
                        BuyerId = buyer1.Id,
                        SellerId = seller1.Id,
                        Items = new List<ItemEntity> { iphone },
                        FinalPrice = iphone.Price,
                        OrderStatus = "Completed"
                    },
                    new OrderEntity
                    {
                        BuyerId = buyer2.Id,
                        SellerId = seller2.Id,
                        Items = new List<ItemEntity> { sofa },
                        FinalPrice = sofa.Price,
                        OrderStatus = "Completed"
                    }
                };

                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }

            // ---------- REVIEWS ----------
            if (!context.Reviews.Any())
            {
                var buyer1 = await userManager.FindByNameAsync("user");
                var buyer2 = await userManager.FindByNameAsync("sofia_buyer");

                var iphone = await context.Items.FirstAsync(i => i.Name.Contains("iPhone"));
                var sofa = await context.Items.FirstAsync(i => i.Name.Contains("Диван"));

                var reviews = new List<ReviewEntity>
                {
                    new ReviewEntity
                    {
                        Title = "Все як описано",
                        Description = "Телефон в чудовому стані, продавець відповідав швидко.",
                        Rating = 5,
                        AuthorId = buyer1.Id,
                        ItemId = iphone.Id
                    },
                    new ReviewEntity
                    {
                        Title = "Гарний диван, але доставка затрималась",
                        Description = "Якість відповідає ціні, трохи довше чекала на самовивіз.",
                        Rating = 4,
                        AuthorId = buyer2.Id,
                        ItemId = sofa.Id
                    }
                };

                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }


        }
    }
}
