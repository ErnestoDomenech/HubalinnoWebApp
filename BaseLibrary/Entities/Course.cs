namespace BaseLibrary.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }    

        public virtual ICollection<Tutor>? Tutors { get; set; } = [];
        public virtual ICollection<StudentEnrollment>? Enrollments { get; set; } = [];
    }
}