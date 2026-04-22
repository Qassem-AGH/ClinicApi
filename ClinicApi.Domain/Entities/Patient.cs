namespace ClinicApi.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}