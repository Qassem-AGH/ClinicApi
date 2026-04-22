namespace ClinicApi.Application.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
}