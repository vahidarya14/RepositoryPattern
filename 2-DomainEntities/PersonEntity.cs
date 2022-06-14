namespace _2_DomainEntities
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonEntity() { }

        public PersonEntity(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}