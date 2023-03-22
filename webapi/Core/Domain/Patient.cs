using CsvHelper.Configuration;

namespace webapi.Core.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
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
