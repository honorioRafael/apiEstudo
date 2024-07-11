namespace apiEstudo.Domain.Models
{
    public class User : BaseEntry<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User()
        { }
    }
}
