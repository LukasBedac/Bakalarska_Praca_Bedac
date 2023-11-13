namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class User
    {
        private int _id;
        private string? _name;
        private string? _email;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }


        public User AddUser(int id, string? name, string? email)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            user.Email = email;
            return user;
        } 
    }

    
}
