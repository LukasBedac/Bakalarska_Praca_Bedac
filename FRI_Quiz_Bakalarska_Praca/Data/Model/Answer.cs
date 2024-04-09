using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Text { get; set; }
        
        [Required]
        public int Order { get; set; }
        
        [Required]
        public bool Correct { get; set; }
        
        [Required]
        public Question Question { get; set; }

        [NotMapped]
        public bool isChecked { get; set; }
    }
}
