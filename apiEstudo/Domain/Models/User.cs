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

        //public static implicit operator OutputUser(User user)
        //{
        //    return user == null ? default : new OutputUser { Id = user.Id };
        //}
    }
}
