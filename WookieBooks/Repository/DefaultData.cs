using Microsoft.EntityFrameworkCore;
using WookieBooks.Interfaces;
using WookieBooks.Models;

namespace WookieBooks.Repository
{
    public static class DefaultData
    {
        public static void Initaialize(IBookRepository bookRepository)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                if (context.Books.Any())
                {
                    // database already seeded
                    return;
                }

                context.Books.Add(new Book()
                {
                    Title = "What's Weirder Than A Wookiee?",
                    Description = "Meet some friendly (and not so friendly) creatures from across the Star Wars galaxy. Read about what they look like, where they live and who their friends are.",
                    Author = "Laura Buller",
                    CoverImage = "~/images/book1.png",
                    Price = 9.99m
                });
                context.Books.Add(new Book()
                {
                    Title = "A Forest Apart",
                    Description = "Lumpawarrump finds a burglar at Han and Leia Solo's apartment and pursues him into Coruscant's dangerous under-levels. Chewbacca and his wife, Mallatobuck, follow their son to find him fighting the burglar in the company of a band of thieves.",
                    Author = "Troy Denning",
                    CoverImage = "~/images/book2.png",
                    Price = 14.99m
                });
                context.SaveChanges();
            }
        }
    }
}   
