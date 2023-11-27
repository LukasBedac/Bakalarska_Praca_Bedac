using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)] 
        public string? Name { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }

    }


}
