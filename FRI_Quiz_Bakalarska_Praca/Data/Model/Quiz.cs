using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;


namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Quiz
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public TypKvizu Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string? QuizName { get; set; }

        [Required]
        public List<Question> Questions { get; set; } = new List<Question>();

        [Required]
        public DateTime? DateFrom { get; set; }

        [Required]
        public DateTime? DateTo { get; set; }
       
        [Required]
        public string? Description { get; set; } = " ";
        
        [Required]
        public IdentityUser<int>? User { get; set; }

        public List<IdentityUser<int>> Moderators { get; set; } = new List<IdentityUser<int>>();
    }

    public enum TypKvizu
    {
        livekviz,
        kviz
    }
}
