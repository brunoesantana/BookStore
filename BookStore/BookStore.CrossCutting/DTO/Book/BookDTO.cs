using System;

namespace BookStore.CrossCutting.DTO.Book
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string UrlImage { get; set; }
    }
}
