namespace ClinicApi.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Notes { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}