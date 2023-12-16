using System.Text.RegularExpressions;

namespace Final_work_OOP_SA22
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            var r = new Regex(Helper.MatchNamePattern);
            if (r.IsMatch(firstName) || r.IsMatch(lastName))
            {
                FirstName = firstName;
                LastName = lastName;
            }
            else
                throw new Exception("Невірне ім'я або прізвище.У полі не може бути цифр");
        }

        public Person()
        {
            
        }

        public Person(string Fullname)
        {
            var r = new Regex(Helper.MatchFullNamePattern);
            if (r.IsMatch(Fullname))
            {
                var splited = Fullname.Split(' ');
                FirstName = splited[0];
                LastName = splited[1];
            }
            else
            {
                throw new Exception("Невірне ім'я або прізвище.");
            }

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
