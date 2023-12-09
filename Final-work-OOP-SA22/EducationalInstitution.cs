

namespace Final_work_OOP_SA22
{
    public abstract class EducationalInstitution
    {

        private string _name;
        private string Name { get; set; }
        private AccreditationLevels accreditationLevel;

        private readonly DateTime foundationDate;

        private int studentQuantity;

        private Person headOfInstitution;

        private int Rating;

        private string phoneNumber;

        public EducationalInstitution()
        {
        }

        public EducationalInstitution(string name, AccreditationLevels accreditationLevel,
            DateTime foundationDate, int studentQuantity, Person headOfInstitution,
            int rating, string phoneNumber)
        {
            Name = name;
            this.accreditationLevel = accreditationLevel;
            this.foundationDate = foundationDate;
            this.studentQuantity = studentQuantity;
            this.headOfInstitution = headOfInstitution;
            Rating = rating;
            this.phoneNumber = phoneNumber;
        }

        public EducationalInstitution(EducationalInstitution institution)
        {
            Name = institution.Name;
            this.accreditationLevel = institution.accreditationLevel;
            this.foundationDate = institution.foundationDate;
            this.studentQuantity = institution.studentQuantity;
            this.headOfInstitution = institution.headOfInstitution;
            Rating = institution.Rating;
            this.phoneNumber = institution.phoneNumber;
        }

        public abstract void PrintInfo();
    }

    public enum AccreditationLevels
    {
        School = 1,
        College,
        Institute,
        University
    }


}
