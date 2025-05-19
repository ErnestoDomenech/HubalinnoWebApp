
namespace BaseLibrary.Entities
{
    public class Administrator: BaseEntity
    {
        public virtual AdminProfile? Profile { get; set; }
    }
}
