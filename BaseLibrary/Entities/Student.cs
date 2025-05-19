
namespace BaseLibrary.Entities
{
    public class Student : BaseEntity
    {
        public DateTime Created { get; set; }
        public virtual StudentProfile? Profile { get; set; }
    }
}
