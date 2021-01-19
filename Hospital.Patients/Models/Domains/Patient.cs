namespace Hospital.Patients.Models.Domains
{
    class Patient
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string SocialSecurityNumber { get; }

        public Patient(int id, string firstName, string lastName, string socialSecurityNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}