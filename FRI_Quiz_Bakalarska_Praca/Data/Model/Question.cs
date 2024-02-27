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

        [Required]
        public string? Text { get; set; } = " ";

        [ForeignKey(nameof(Answer.Id))]
        [Required]
        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        
        [Required]
        public int Order { get; set; }

        //TODO 1.9 Skusit to zmenit na Quiz.Id
        [ForeignKey(nameof(Quiz.Id))]
        [Required]
        public virtual Quiz? QuizRef { get; set; }
    }
}
