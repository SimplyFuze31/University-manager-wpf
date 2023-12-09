namespace Final_work_OOP_SA22
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name:{FirstName} {LastName}";
        }
    }
}
