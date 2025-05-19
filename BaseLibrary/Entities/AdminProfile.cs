namespace BaseLibrary.Entities
{
    public class AdminProfile
    {
        public int AdministratorId { get; set; }
        public int CivilId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual Administrator? Administrator { get; set; }
    }
}