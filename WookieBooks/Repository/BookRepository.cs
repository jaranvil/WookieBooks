using Microsoft.EntityFrameworkCore;
using WookieBooks.Interfaces;
using WookieBooks.Models;

namespace WookieBooks.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Get(int page, int count)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                return context.Books.Skip((page - 1) * count).Take(count).ToList();
            }

        }

        public Book? Get(int id)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                return context.Books.Where(b => b.ID == id).FirstOrDefault();
            }                
        }

        public async Task<Book> Create(Book book)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
                return book;
            }
        }
      
        public async Task<Book?> Update(Book book)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                var existingBook = context.Books.FirstOrDefault(b => b.ID == book.ID);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title ?? existingBook.Title;
                    existingBook.Description = book.Description ?? existingBook.Description;
                    existingBook.Author = book.Author ?? existingBook.Author;
                    existingBook.CoverImage = book.CoverImage ?? existingBook.CoverImage;
                    existingBook.Price = book.Price > 0 ? book.Price : existingBook.Price;

                    await context.SaveChangesAsync();
                    return existingBook;
                }
                return null;
            }
        }
     
        public async Task<bool> Delete(int id)
        {
            var options = new DbContextOptionsBuilder<WookieContext>().UseInMemoryDatabase(databaseName: "Books").Options;
            using (var context = new WookieContext(options))
            {
                var existingBook = context.Books.FirstOrDefault(b => b.ID == id);
                if (existingBook != null)
                {
                    context.Books.Remove(existingBook);
                    await context.SaveChangesAsync();
                    return true;
                }
                
            }
            return false;
        }
    }
}
