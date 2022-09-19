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

    public Enemy GetEnemyById(int enemyId)
    {
        var enemy = _context.Enemies.FirstOrDefault(e => e.EnemyId == enemyId);
        if (enemy == default)
            throw new Exception($"Enemy with Id({enemyId}) was not found!");
        return enemy;
    }
    
    public void AddEnemy(Enemy enemy)
    {
        _context.Enemies.Add(enemy);
        _context.SaveChanges();
    }

    public void ModifyEnemyName(Enemy enemy, string newName)
    {
        enemy.EnemyName = newName;
        _context.SaveChanges();
    }
    
    public void ModifyEnemyDescription(Enemy enemy, string newDescription)
    {
        enemy.Description = newDescription;
        _context.SaveChanges();
    }

    public void DeleteEnemy(int enemyId)
    {
        var enemyToDelete = _context.Enemies.FirstOrDefault(e => e.EnemyId.Equals(enemyId));

        if (enemyToDelete == default)
            throw new Exception($"Enemy with id {enemyId} not found!");
        
        _context.Enemies.Remove(enemyToDelete);
        _context.SaveChanges();
    }
    
    public string? GetEnemiesForEpisode(int episodeId)
    {
        var companions = _context.Episodes.Select(e => _context.GetEnemies(episodeId)).FirstOrDefault();
        return companions;
    }

    private async Task<Episode?> GetEpisodeAsync(int episodeId)
    {
        return await _context.Episodes.FirstOrDefaultAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task<bool> EpisodeExistsAsync(int episodeId)
    {
        return await _context.Episodes.AnyAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task AddEnemyToEpisodeAsync(int episodeId, Enemy enemy)
    {
        var episode = await GetEpisodeAsync(episodeId);

        var episodeEnemyToAdd = new EpisodeEnemy
        {
            Episode = episode!,
            Enemy = enemy
        };
        episode!.EpisodeEnemies.Add(episodeEnemyToAdd);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}