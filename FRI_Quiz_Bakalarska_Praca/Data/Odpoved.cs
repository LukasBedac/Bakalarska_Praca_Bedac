namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class Odpoved
    {
        private int _id;
        private string? _text;
        private bool _spravna;
        private string? _poriadie;

        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Poriadie { get; set; }
        public bool Spravna { get; set;}

    }
}
