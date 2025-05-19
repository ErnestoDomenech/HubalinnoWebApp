namespace BaseLibrary.Entities
{
    public class StudentEnrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Progress { get; set; }
        public double Score { get; set; }
        public DateTime FirstAccess { get; set; }
        public DateTime LastAccess { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}