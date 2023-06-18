using HospitalWebApi.Models;
using HospitalWebApi.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Repositories
{
    public class HospitalRepositoryContext : DbContext
    {


        public HospitalRepositoryContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Patient> Patients { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfig());
        }


    }
}
