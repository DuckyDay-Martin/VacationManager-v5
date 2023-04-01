namespace VacationManager_v5.Models
{
    public class Teams
    {

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string ProjectWorkingOn { get; set; }

        public virtual ICollection<Users> Developers { get; set; }

        public virtual Users TeamLead { get; set; }



    }
}
