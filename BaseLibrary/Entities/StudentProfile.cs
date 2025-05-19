namespace BaseLibrary.Entities
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? CivilId { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Student? Student { get; set; }
    }
}