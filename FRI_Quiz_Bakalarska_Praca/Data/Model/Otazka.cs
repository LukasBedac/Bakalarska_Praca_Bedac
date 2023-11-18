using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Otazka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Nazov { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Text { get; set; } = " ";
        [Required]
        [Length(2, 6)]
        [DefaultValue(4)]
        public LinkedList<Odpoved>? Odpovede { get; set; }
        [Required]
        public int Poradie { get; set; }

    }
}
