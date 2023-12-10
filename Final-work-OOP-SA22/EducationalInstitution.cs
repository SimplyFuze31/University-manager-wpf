

namespace Final_work_OOP_SA22
{ 
    internal abstract class EducationalInstitution
    {

        protected string name;
        
        public string Name
        {
            get { return name; }
        }
        
        protected AccreditationLevels accreditationLevel;

        protected DateTime foundationDate;

        protected int studentQuantity;

        protected Person headOfInstitution;

        protected int rating;

        protected string phoneNumber;

        public EducationalInstitution()
        {
        }

        public EducationalInstitution(string name, AccreditationLevels accreditationLevel,
            DateTime foundationDate, int studentQuantity, Person headOfInstitution,
            int rating, string phoneNumber)
        {
            this.name = name;
            this.accreditationLevel = accreditationLevel;
            this.foundationDate = foundationDate;
            this.studentQuantity = studentQuantity;
            this.headOfInstitution = headOfInstitution;
            this.rating = rating;
            this.phoneNumber = phoneNumber;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
            name = institution.name;
            this.accreditationLevel = institution.accreditationLevel;
            this.foundationDate = institution.foundationDate;
            this.studentQuantity = institution.studentQuantity;
            this.headOfInstitution = institution.headOfInstitution;
            this.rating = institution.rating;
            this.phoneNumber = institution.phoneNumber;
        }
        
        public abstract void RemoveDepartment(string departmentName);
        public abstract void PrintInfo();
        
        
    }
    
}
