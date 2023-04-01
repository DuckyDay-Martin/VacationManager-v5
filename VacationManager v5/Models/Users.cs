namespace VacationManager_v5.Models
{
    public class Users
    {
        public Users(string userID, string userName, string password, string firstName, string lastName, string role, int teamId)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            TeamId = teamId;
        }

        public string UserID { get; set; } 

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public int TeamId { get; set; }

        public virtual Teams Team { get; set; }


    }
}
