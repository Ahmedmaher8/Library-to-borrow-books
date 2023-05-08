using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Borrower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Coede { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<BorrowBooks> BorrowBooks { get; set; }=new List<BorrowBooks>();   


    }
}
