namespace VacationManager_v5.Models
{
    public class VacationRequest
    {
        public int VacationId { get; set; }

        public string VacationName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //Дали е цял ден или не
        public bool IsAllDay { get; set; }

        public bool Status { get; set; }

        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
