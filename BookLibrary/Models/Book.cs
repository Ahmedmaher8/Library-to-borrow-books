using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberOfBooks { get; set; }

        public int NumberOfBorroedBooks { get; set; }
        public virtual ICollection<BorrowBooks> BorrowBooks { get; set; } = new List<BorrowBooks>();

    }
}
