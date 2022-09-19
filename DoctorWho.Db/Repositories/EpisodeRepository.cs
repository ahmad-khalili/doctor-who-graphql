using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EpisodeRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Episode>> GetEpisodesAsync(int pageNumber, int pageSize)
    {
        var collection = _context.Episodes as IQueryable<Episode>;

        var collectionToReturn = await collection.OrderBy(e => e.SeriesNumber)
            .ThenBy(e => e.EpisodeNumber)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return collectionToReturn;
    }

    public async Task AddEpisodeAsync(Episode episode)
    {
        await _context.Episodes.AddAsync(episode);
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.AuthorId.Equals(authorId));
    }

    public async Task<bool> DoctorExistsAsync(int doctorId)
    {
        return await _context.Doctors.AnyAsync(d => d.DoctorId.Equals(doctorId));
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}