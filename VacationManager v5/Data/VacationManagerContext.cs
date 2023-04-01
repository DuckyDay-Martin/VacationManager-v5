using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using VacationManager_v5.Models;

namespace VacationManager_v5.Data
{
    public class VacationManagerContext : DbContext
    {
        public VacationManagerContext(DbContextOptions<VacationManagerContext> options) 
            : base(options)
        {


        }

        //Таблицата/ колоните
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<VacationRequest> VacationRequests { get; set; }

    }
}
