using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Entities;
[Table(nameof(Episode))]
public class Episode
{
    public Episode()
    {
        EpisodeEnemies = new List<EpisodeEnemy>();
        EpisodeCompanions = new List<EpisodeCompanion>();
    }
    
    public int EpisodeId { get; set; }
    public int SeriesNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public string EpisodeType { get; set; }
    public string Title { get; set; }
    public DateTime EpisodeDate { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public string Notes { get; set; }

    public List<EpisodeEnemy> EpisodeEnemies { get; set; }

    public List<EpisodeCompanion> EpisodeCompanions { get; set; }
}