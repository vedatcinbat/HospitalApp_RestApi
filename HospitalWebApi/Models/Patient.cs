namespace HospitalWebApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string patientName { get; set; } = string.Empty;
        public string patientSurname { get; set; } = string.Empty;
        public string patientFrom { get; set; } = string.Empty;

    }
}
