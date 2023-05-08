using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class BorrowBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; } 
        public Book Book { get; set; }
        [ForeignKey("Borrower")]
        public int BorrowID { get; set; }  
        public Borrower Borrower { get; set; }

        public actionTypeEnum actionType { get; set; }

    }
    public enum actionTypeEnum
    {
        Borrow,Return
    }
}
