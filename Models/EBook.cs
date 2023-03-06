using System.ComponentModel.DataAnnotations;
namespace Projet_EBook.Models
{
    public class EBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public  string auteur { get; set; }
        public string Description { get; set; }
        public float prix { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
