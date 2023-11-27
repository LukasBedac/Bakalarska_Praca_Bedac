using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Odpoved
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string? Text { get; set; }
        
        [Required]
        public int Poradie { get; set; }
        
        [Required]
        public bool Spravna { get; set; }

    }
}
