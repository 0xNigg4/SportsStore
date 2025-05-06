// Models/SeedData.cs
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // Create database if it doesn't exist
                context.Database.EnsureCreated();

                // Check if database is already populated
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Football",
                            Description = "Official size and weight",
                            Category = "Soccer",
                            Price = 25.99M
                        },
                        new Product
                        {
                            Name = "Soccer Ball",
                            Description = "FIFA-approved size and weight",
                            Category = "Soccer",
                            Price = 19.50M
                        },
                        new Product
                        {
                            Name = "Running Shoes",
                            Description = "Lightweight running shoes",
                            Category = "Running",
                            Price = 95.00M
                        },
                        new Product
                        {
                            Name = "Basketball",
                            Description = "NBA-sized basketball",
                            Category = "Basketball",
                            Price = 29.95M
                        },
                        new Product
                        {
                            Name = "Tennis Racket",
                            Description = "Professional tennis racket",
                            Category = "Tennis",
                            Price = 79.95M
                        },
                        new Product
                        {
                            Name = "Baseball Glove",
                            Description = "Leather baseball glove",
                            Category = "Baseball",
                            Price = 49.95M
                        },
                        new Product
                        {
                            Name = "Swimming Goggles",
                            Description = "Anti-fog swimming goggles",
                            Category = "Swimming",
                            Price = 15.95M
                        },
                        new Product
                        {
                            Name = "Yoga Mat",
                            Description = "Non-slip yoga mat",
                            Category = "Fitness",
                            Price = 29.95M
                        },
                        new Product
                        {
                            Name = "Dumbbells",
                            Description = "Set of 2 dumbbells (5kg each)",
                            Category = "Fitness",
                            Price = 45.50M
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}