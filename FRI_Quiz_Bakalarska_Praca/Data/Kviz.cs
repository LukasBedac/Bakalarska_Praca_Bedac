namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class Kviz
    {
        private int id;
        private int id_user;
        private string? nazov;
        private DateTime? datumOd;
        private DateTime? datumDo;
        private string? popis;

        public int Id { get; set; }
        public int UserId { get; set; }
         
        public string? Nazov { get; set; }
        
        public DateTime? DatumOd { get; set;}
        public DateTime? DatumDo { get; set;}
        public string? Popis { get; set; } = null;
    }
}
