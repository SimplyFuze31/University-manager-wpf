

using System.Text.RegularExpressions;

namespace Final_work_OOP_SA22
{ 
    public abstract class EducationalInstitution
    {
        protected Guid _id;
        public Guid Id { get; }
        protected string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _name = "Noname institution";
                else if (new Regex(Helper.MatchNamePattern).IsMatch(value))
                    _name = "Not valid institution name";
                else
                    _name = value;
            }
        }
        protected AccreditationLevels _accreditationlevel;
        public AccreditationLevels AccreditationLevel
        {
            get { return _accreditationlevel; }
            set { _accreditationlevel = value; }
        }
        protected DateTime _foundationDate;
        public DateTime FoundationDate
        {
            get { return _foundationDate; }
            set {
                if (value > DateTime.Now)
                    _foundationDate = DateTime.Now;
                else _foundationDate = value;

            }
        }
        protected int _numberofstudents;
        
        public int NumberOfStudents
        {
            get { return _numberofstudents; }
            set
            {
                if (value > 0 && this is Department)
                    _numberofstudents = value;
            }
        }

        protected Person _headOfInstitution;
        public Person HeadOfInstitution
        {
            get {  return _headOfInstitution; }
            set { _headOfInstitution = value; }
        }

        protected int _rating;
        
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value > 100)
                    _rating = 100;
                else if (value < 0)
                    _rating = 0;
                else
                    _rating = value;
            }
        }

        protected string _phonenumber;
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                //if (Helper.IsValidPhone(value))
                    _phonenumber = value;
            }
        }

        public EducationalInstitution()
        {
            _id = Guid.NewGuid();
        }

        public EducationalInstitution(string name, AccreditationLevels accreditationlevel,
            DateTime foundationDate, Person headOfInstitution)
        {
            _id = Guid.NewGuid();
            _name = name;
            _accreditationlevel = accreditationlevel;
            _foundationDate = foundationDate;
            _headOfInstitution = headOfInstitution;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
            _id = Guid.NewGuid();
            _name = institution._name;
            _accreditationlevel = institution._accreditationlevel;
            _foundationDate = institution._foundationDate;
            _headOfInstitution = institution._headOfInstitution;
            _rating = institution._rating;
            _phonenumber = institution._phonenumber;
        }
        
        public abstract int GetNumberOfStudents();
    }
    
}
