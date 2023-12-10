

namespace Final_work_OOP_SA22
{ 
    public abstract class EducationalInstitution
    {

        protected string _name;
        
        public string Name
        {
            get { return _name; }
        }
        
        protected AccreditationLevels accreditationLevel;

        protected DateTime foundationDate;

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
        }

        protected string phoneNumber;

        public EducationalInstitution()
        {
        }

        public EducationalInstitution(string name, AccreditationLevels accreditationLevel,
            DateTime foundationDate, Person headOfInstitution,
            int rating, string phoneNumber)
        {
            this._name = name;
            this.accreditationLevel = accreditationLevel;
            this.foundationDate = foundationDate;
            // TODO: Make student count

            this._headOfInstitution = headOfInstitution;
            this._rating = rating;
            this.phoneNumber = phoneNumber;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
            _name = institution._name;
            this.accreditationLevel = institution.accreditationLevel;
            this.foundationDate = institution.foundationDate;
            this._numberofstudents = institution._numberofstudents;
            this._headOfInstitution = institution._headOfInstitution;
            this._rating = institution._rating;
            this.phoneNumber = institution.phoneNumber;
        }
        
        public abstract void RemoveDepartment(string departmentName);

        public abstract int GetNumberOfStudents();
        
        
    }
    
}
