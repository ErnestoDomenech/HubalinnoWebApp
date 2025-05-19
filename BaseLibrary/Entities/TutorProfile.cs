namespace BaseLibrary.Entities
{
    public class TutorProfile
    {
        public int Id { get; set; }
        public int TutorId { get; set; }
        public string? CivilId { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Tutor? Tutor { get; set; }
    }
}