using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;
public class EpisodeEnemyRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EpisodeEnemyRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddEnemyToEpisode(Enemy enemy, Episode episode)
    {
        if (!_context.Enemies.Contains(enemy)) throw new ArgumentException("Enemy doesn't exist!");
        if (!_context.Episodes.Contains(episode)) throw new ArgumentException("Episode doesn't exist!");

        var newEpisodeEnemy = new EpisodeEnemy
        {
            EnemyId = enemy.EnemyId,
            EpisodeId = episode.EpisodeId
        };

        _context.EpisodeEnemies.Add(newEpisodeEnemy);
    }
}