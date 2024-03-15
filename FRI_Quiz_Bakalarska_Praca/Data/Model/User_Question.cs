using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class User_Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User ActualUser { get; set; }

        [Required]
        public Question ActualQuestionId { get; set; }

        public List<Answer> CheckedAnswers { get; set; } = new List<Answer>() { };

        [Required]
        public DateTime? DateOpen { get; set; }

        [Required]
        public DateTime? DateClose { get; set; }   
        
    }
}
