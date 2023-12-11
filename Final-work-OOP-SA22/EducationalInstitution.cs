

namespace Final_work_OOP_SA22
{ 
    public abstract class EducationalInstitution
    {
        protected string _name;
        public string Name
        {
            get { return _name; }
        }
        protected AccreditationLevels _accreditationlevel;
        public AccreditationLevels AccreditationLevel
        {
            get { return _accreditationlevel; }
        }
        protected DateTime _foundationDate;
        public DateTime FoundationDate
        {
            get { return _foundationDate; }
        }
        protected int _numberofstudents;
        
        public int NumberOfStudents
        {
            get { return _numberofstudents; }
        }

        protected Person _headOfInstitution;
        public Person HeadOfInstitution
        {
            get {  return _headOfInstitution; }
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
                if (Helper.IsValidPhone(value))
                    _phonenumber = value;
            }
        }
        
        public EducationalInstitution() { }

        public EducationalInstitution(string name, AccreditationLevels accreditationlevel,
            DateTime foundationDate, Person headOfInstitution)
        {
            _name = name;
            _accreditationlevel = accreditationlevel;
            _foundationDate = foundationDate;
            _headOfInstitution = headOfInstitution;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
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
