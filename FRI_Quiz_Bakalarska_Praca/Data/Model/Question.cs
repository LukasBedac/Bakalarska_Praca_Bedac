using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; } = " ";
        
        [Required]
        public List<Answer> Answers { get; set; } = new List<Answer>();
        
        [Required]
        public int Order { get; set; }

        [Required]
        public virtual Quiz? Quiz { get; set; }
    }
}
