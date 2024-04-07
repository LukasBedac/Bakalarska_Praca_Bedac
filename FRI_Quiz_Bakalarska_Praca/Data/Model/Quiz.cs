using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;


namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Quiz
    {

        [Key]
        public int Id { get; set; }

        [NotNull]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid Hash { get; set; }

        [Required]
        public TypKvizu Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string QuizName { get; set; } = string.Empty;

        [Required]
        public virtual List<Question> Questions { get; set; } = new List<Question>();

        [Required]
        public DateTime? DateFrom { get; set; }

        [Required]
        public DateTime? DateTo { get; set; }
       
        [Required]
        public User User { get; set; }

        public List<User> Moderators { get; set; } = new List<User>();

        [NotMapped]
        public virtual int QuestionCount => Questions?.Count ?? 0;

    }

    
    public enum TypKvizu
    {
        livekviz,
        kviz
    }
}
