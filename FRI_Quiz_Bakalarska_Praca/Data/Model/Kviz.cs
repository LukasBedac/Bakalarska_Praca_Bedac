using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;


namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Kviz
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public TypKvizu Typ { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nazov { get; set; }

        [Required]
        public List<Otazka> Otazky { get; set; } = new List<Otazka>();

        [Required]
        public DateTime? DatumOd { get; set; }

        [Required]
        public DateTime? DatumDo { get; set; }
        
        [Required]
        public TimeSpan TimeFrom { get; set; }
        
        [Required]
        public TimeSpan TimeTo { get; set; }

        [Required]
        public string? Popis { get; set; } = " ";
        
        [Required]
        public IdentityUser<int> User { get; set; }

        public List<IdentityUser<int>> Moderator { get; set; } = new List<IdentityUser<int>>();
    }

    public enum TypKvizu
    {
        livekviz,
        kviz
    }
}
