using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int CorrectNumberOfAnswers()
        {
            int correct = 0;
            if (CheckedAnswers == null || CheckedAnswers.Count < 1)
            {
                return correct;
            }
            foreach (var item in CheckedAnswers)
            {
                if (item.Correct)
                {
                    ++correct;
                }
            }
            return correct;
        }
    }

    
}
