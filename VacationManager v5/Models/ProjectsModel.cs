namespace VacationManager_v5.Models
{
    public class ProjectsModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public virtual ICollection<Teams> WorkingTeam { get; set; }
    }
}
