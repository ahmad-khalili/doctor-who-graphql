namespace DoctorWho.Db.Models;

public class DoctorForUpsertionDto
{
    public int DoctorNumber { get; set; }
    public string DoctorName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? FirstEpisodeDate { get; set; }
    public DateTime? LastEpisodeDate { get; set; }
}