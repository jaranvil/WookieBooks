using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooks.Interfaces
{    
    public interface IBookRepository 
    {
        List<Book> Get(int page, int count);
        Book? Get(int id);
        Task<Book> Create(Book book);
        Task<Book?> Update(Book book);
        Task<bool> Delete(int id);
    }
}
