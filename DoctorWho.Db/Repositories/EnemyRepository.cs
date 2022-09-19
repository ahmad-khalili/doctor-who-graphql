using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EnemyRepository : IEnemyRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EnemyRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task AddEnemyToEpisodeAsync(int episodeId, Enemy enemy)
    {
        var episode = await _context.Episodes.FirstOrDefaultAsync(e => e.EpisodeId.Equals(episodeId));

        var episodeEnemy = new EpisodeEnemy
        {
            Enemy = enemy,
            Episode = episode!
        };

        await _context.EpisodeEnemies.AddAsync(episodeEnemy);
    }

    public async Task<bool> EpisodeExistsAsync(int episodeId)
    {
        return await _context.Episodes.AnyAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}