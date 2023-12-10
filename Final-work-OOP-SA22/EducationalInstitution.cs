

namespace Final_work_OOP_SA22
{ 
    public abstract class EducationalInstitution
    {

        protected string name;
        
        public string Name
        {
            get { return name; }
        }
        
        protected AccreditationLevels accreditationLevel;

        protected DateTime foundationDate;

        protected int _numberofstudents;

        protected Person headOfInstitution;
        
        public string HeadOfInstitution
        {
            get { return headOfInstitution.ToString(); }
        }

        protected int rating;
        
        public int Rating
        {
            get { return rating; }
        }

        protected string phoneNumber;

        public EducationalInstitution()
        {
        }

        public EducationalInstitution(string name, AccreditationLevels accreditationLevel,
            DateTime foundationDate, Person headOfInstitution,
            int rating, string phoneNumber)
        {
            this.name = name;
            this.accreditationLevel = accreditationLevel;
            this.foundationDate = foundationDate;
            // TODO: Make student count

            this.headOfInstitution = headOfInstitution;
            this.rating = rating;
            this.phoneNumber = phoneNumber;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
            name = institution.name;
            this.accreditationLevel = institution.accreditationLevel;
            this.foundationDate = institution.foundationDate;
            this._numberofstudents = institution._numberofstudents;
            this.headOfInstitution = institution.headOfInstitution;
            this.rating = institution.rating;
            this.phoneNumber = institution.phoneNumber;
        }
        
        public abstract void RemoveDepartment(string departmentName);

        public abstract int GetNumberOfStudents();
        public abstract void PrintInfo();
        
        
    }
    
}
