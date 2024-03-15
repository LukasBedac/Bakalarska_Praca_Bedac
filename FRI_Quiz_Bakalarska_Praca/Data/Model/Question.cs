using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public Guid Hash { get; set; }

        [Required]
        public string? Text { get; set; } = " ";

        [Required]
        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        
        [Required]
        public int Order { get; set; }

        [Required]
        public virtual Quiz QuizRef { get; set; }
    }
}
