﻿namespace Final_work_OOP_SA22.Factories;

public abstract class EducationalInstitutionFactory{
    
    protected Guid _id;
    protected string _name;

    protected AccreditationLevels _accreditationlevel;

    protected DateTime _foundationDate;

    protected int _numberofstudents;

    protected Person _headOfInstitution;

    protected int _rating;
    
    protected string _phonenumber;

    public EducationalInstitutionFactory() { }
    public EducationalInstitutionFactory(string name, DateTime foundationdate,
        Person headofinstitution, int rating, string phonenumber)
    {
        _id = Guid.NewGuid();
        _name = name;
        _foundationDate = foundationdate;
        _headOfInstitution = headofinstitution;
        _rating = rating;
        _phonenumber = phonenumber;
    }
    
    

    public abstract EducationalInstitution GetEducationalInstitution();
}