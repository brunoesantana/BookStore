using BookStore.CrossCutting.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace BookStore.CrossCutting.DTO.Book
{
    public class BookUpdateDTO : BaseUpdateDTO
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
