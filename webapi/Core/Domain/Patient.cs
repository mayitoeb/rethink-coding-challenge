using CsvHelper.Configuration;

namespace webapi.Core.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get;  set; }
        public string Gender { get; set; }

        public Patient()
        {
            
        }

        public Patient(Guid id,  string firstName, string lastName, DateTime birthday, string gender)
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
