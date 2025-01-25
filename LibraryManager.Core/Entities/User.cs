namespace LibraryManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email) : base()
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        public void Update(string name, string email)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (!string.IsNullOrWhiteSpace(name))
                Email = email;
        }

    }
}
