using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Models;

[Keyless]
public class EpisodeSummaryCompanion
{
    public string CompanionName { get; set; }
    public int TimesAppeared { get; set; }
}