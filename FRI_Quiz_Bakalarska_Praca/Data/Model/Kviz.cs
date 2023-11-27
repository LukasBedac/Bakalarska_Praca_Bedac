﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class Kviz
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Nazov { get; set; }
        
        [Required]
        public List<Otazka>? Otazky { get; set; }
        
        [Required]
        public DateTime? DatumOd { get; set; }
        
        [Required]
        public DateTime? DatumDo { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string? Popis { get; set; } = " ";
    }
}