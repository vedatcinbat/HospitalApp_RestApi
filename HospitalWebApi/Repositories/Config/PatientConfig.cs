using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HospitalWebApi.Models;
namespace HospitalWebApi.Repositories.Config
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(
              new Patient { Id=1, patientName="John", patientSurname = "Stones", patientFrom = "England" },
              new Patient { Id = 2, patientName = "Vedat", patientSurname = "Cinbat", patientFrom = "Turkey" },
              new Patient { Id = 3, patientName = "Natalie", patientSurname = "Black", patientFrom = "USA" }
            );
        }
    }
}
