using System.Text.RegularExpressions;

namespace Final_work_OOP_SA22
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            var r = new Regex(Helper.MatchNamePattern);
            if (r.IsMatch(firstName))
                throw new Exception("Невірне ім'я.У полі не може бути цифр");
            else
                FirstName = firstName;
            if (r.IsMatch(firstName))
                throw new Exception("Невірне прізвище.У полі не може бути цифр");
            else
                LastName = lastName;

        }

        public Person()
        {
            
        }

        public Person(string Fullname)
        {
            var splited = Fullname.Split(' ');
            FirstName = splited[0];
            LastName = splited[1];
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
