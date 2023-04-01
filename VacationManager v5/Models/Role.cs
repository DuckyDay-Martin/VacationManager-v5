namespace VacationManager_v5.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
