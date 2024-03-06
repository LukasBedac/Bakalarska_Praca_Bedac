namespace FRI_Quiz_Bakalarska_Praca.Data.Model
{
    public class User_Question
    {
        public int Id { get; set; }

        public User ActualUser { get; set; }

        public int ActualQuestionId { get; set; } //Or hash(GUID)


    }
}
