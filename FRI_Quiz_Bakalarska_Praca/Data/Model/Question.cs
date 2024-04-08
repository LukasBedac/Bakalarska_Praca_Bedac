using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [NotNull]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid Hash { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required]
        public string? Text { get; set; } = " ";

        [Required]
        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        
        [Required]
        public int Order { get; set; }

        [DefaultValue(false)]
        public bool Shown { get; set; }

        [Required]
        public virtual Quiz Quiz { get; set; }
    }
}
