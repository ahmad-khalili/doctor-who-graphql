using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Entities;
[Table(nameof(Enemy))]
public class Enemy
{
    public Enemy()
    {
        EpisodesEnemies = new List<EpisodeEnemy>();
    }
    
    public int EnemyId { get; set; }
    public string EnemyName { get; set; }
    public string Description { get; set; }

    public List<EpisodeEnemy> EpisodesEnemies { get; set; }
}