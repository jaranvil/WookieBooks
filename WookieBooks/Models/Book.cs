using System.ComponentModel.DataAnnotations;

namespace WookieBooks.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? CoverImage { get; set; }
        public decimal Price { get; set; }

    }
}
