using LibApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static  void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()
                ))
            {
                
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes already seeded");
                    
                }
                else
                {
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay as You Go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quarterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
                }
                
                // Genres
                if (context.Genre.Any())
                {
                    Console.WriteLine("Genres already seeded");
                    
                }
                else
                {
                    context.Genre.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Thriller"
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Fantasy"
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Reportage"
                    });
                }
                

                //Customers
                if (context.Customers.Any())
                {
                    Console.WriteLine("Customers already seeded");
                    
                }
                else
                {
                    context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Agnieszka Jania",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Birthdate = new DateTime(1990, 7, 23)
                    },
                    new Customer
                    {
                        Name = "Jan Kowalski",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Birthdate = new DateTime(1967, 5, 12)
                    },
                    new Customer
                    {
                        Name = "Katarzyna Nowak",
                        HasNewsletterSubscribed = false,
                        MembershipTypeId = 1,
                        Birthdate = new DateTime(2002, 10, 27)
                    });
                }
                

                //Books
                if (context.Books.Any())
                {
                    Console.WriteLine("Books already seeded");
                    
                }
                else
                {
                   context.Books.AddRange(
                   new Book
                   {
                       Name = "Harry Potter i Kamien Filozoficzny",
                       AuthorName = "J.K.Rowling",
                       GenreId = 2,
                       ReleaseDate = new DateTime(1990, 3, 10),
                       NumberInStock = 20,
                       NumberAvailable = 20,
                       DateAdded = DateTime.Now
                   },
                   new Book
                   {
                       Name = "1984",
                       AuthorName = "George Orwell",
                       GenreId = 3,
                       ReleaseDate = new DateTime(1949, 6, 8),
                       NumberInStock = 10,
                       NumberAvailable = 10,
                       DateAdded = DateTime.Now
                   },
                   new Book
                   {
                       Name = "To",
                       AuthorName = "Stephen King",
                       GenreId = 1,
                       ReleaseDate = new DateTime(1986, 9, 15),
                       NumberInStock = 50,
                       NumberAvailable = 50,
                       DateAdded = DateTime.Now
                   },
                   new Book
                   {
                       Name = "Kane i Abel",
                       AuthorName = "Jeffrey Archer",
                       GenreId = 1,
                       ReleaseDate = new DateTime(1979, 10, 13),
                       NumberInStock = 14,
                       NumberAvailable = 14,
                       DateAdded = DateTime.Now
                   });

                }

                context.SaveChanges();
            }
        }
    }
}
