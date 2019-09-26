using System.ComponentModel.DataAnnotations;

namespace BookStore.CrossCutting.DTO.Book
{
    public class BookInsertDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string UrlImage { get; set; }
    }
}
