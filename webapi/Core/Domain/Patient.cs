using CsvHelper.Configuration;

namespace webapi.Core.Domain
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }
        public char Gender { get; private set; }

        public Patient()
        {
            
        }

        public Patient(Guid id,  string firstName, string lastName, DateTime birthday, char gender)
        {
            Id = id;
            FirstName = firstName ?? string.Empty;
            LastName = lastName ?? string.Empty;
            Birthday = birthday;
            Gender = gender;
        }
    }

    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.Birthday);
            Map(m => m.Gender);
        }
    }
}
