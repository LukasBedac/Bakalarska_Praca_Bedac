namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class Otazka
    {
        private int _id;
        private int _id_quiz;
        private int _id_odpoved;
        private string? _nazov;
        private string? _text;
        private int _poradie;

        public int Id { get; set; }
        public int IdQuiz { get; set; }
        public int IdOdpoved { get; set; }
        public string? Nazov { get; set; }
        public string? Text { get; set; } = null;
        public int Poradie { get; set; }

    }
}
