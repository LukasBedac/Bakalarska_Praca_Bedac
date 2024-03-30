using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class User_Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NotNull]
        public User User { get; set; }

        [Required]
        [NotNull]
        public Question Question { get; set; }

        [Required]
        public List<Answer>? CheckedAnswers { get; set; } = new List<Answer>() { };

        [Required]
        public DateTime? DateAnswered { get; set; } = DateTime.Today;

    }
}
