using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Models;

[Keyless]
public class EpisodeSummaryEnemy
{
    public string EnemyName { get; set; }
    public int TimesAppeared { get; set; }
}