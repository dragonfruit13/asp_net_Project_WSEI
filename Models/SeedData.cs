
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_Project_WSEI.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        
                        ProductName = "qwe",
                        ProductDescription = "qwe",
                        ProductCategory = "Sporty wodne",
                        ProductPrice = 275
                    },
                    new Product
                    {
                        ProductName = "Kamizelka ratunkowa",
                        ProductDescription = "Chroni i dodaje uroku",
                        ProductCategory = "Sporty wodne",
                        ProductPrice = 48.95m
                    },
                    new Product
                    {
                       
                        ProductName = "Piłka",
                        ProductDescription = "Zatwierdzone przez FIFA rozmiar i waga",
                        ProductCategory = "Piłka nożna",
                        ProductPrice = 19.50m
                    },
                    new Product
                    {
                        
                        ProductName = "Flagi narożne",
                        ProductDescription = "Nadadzą twojemu boisku profesjonalny wygląd",
                        ProductCategory = "Piłka nożna",
                        ProductPrice = 34.95m
                    },
                    new Product
                    {
                        
                        ProductName = "Stadiom",
                        ProductDescription = "Składany stadion na 35 000 osób",
                        ProductCategory = "Piłka nożna",
                        ProductPrice = 79500
                    },
                    new Product
                    {
                        
                        ProductName = "Czapka",
                        ProductDescription = "Zwiększa efektywność mózgu o 75%",
                        ProductCategory = "Szachy",
                        ProductPrice = 16
                    },
                    new Product
                    {
                        
                        ProductName = "Niestabilne krzesło",
                        ProductDescription = "Zmniejsza szanse przeciwnika",
                        ProductCategory = "Szachy",
                        ProductPrice = 29.95m
                    },
                    new Product
                    {
                        
                        ProductName = "Ludzka szachownica",
                        ProductDescription = "Przyjemna gra dla całej rodziny!",
                        ProductCategory = "Szachy",
                        ProductPrice = 75
                    },
                    new Product
                    {
                        
                        ProductName = "Błyszczący król",
                        ProductDescription = "Figura pokryta złotem i wysadzana diamentami",
                        ProductCategory = "Szachy",
                        ProductPrice = 1200
                    }
                ) ;
                context.SaveChanges();
            }
        }

    }
}
