using BookStore.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain
{
    public class Book : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        [StringLength(400)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Author { get; set; }

        [Column(TypeName = "VARCHAR(400)")]
        [StringLength(400)]
        public string UrlImage { get; set; }
    }
}
