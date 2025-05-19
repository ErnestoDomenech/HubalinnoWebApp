
namespace BaseLibrary.Entities
{
    public class Tutor: BaseEntity
    {
        public int CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual TutorProfile? Profile { get; set; }
    }
}
