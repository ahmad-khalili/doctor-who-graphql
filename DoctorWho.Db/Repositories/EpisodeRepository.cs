using System.Data;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EpisodeRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public void AddEpisode(Episode episode)
    {
        _context.Episodes.Add(episode);
        _context.SaveChanges();
    }

    public void ModifyEpisodeTitle(Episode episode, string newTitle)
    {
        episode.Title = newTitle;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeDoctor(Episode episode, Doctor newDoctor)
    {
        if (!_context.Doctors.Contains(newDoctor)) throw new ArgumentException("Doctor doesn't exist!");

        episode.DoctorId = newDoctor.DoctorId;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeAuthor(Episode episode, Author newAuthor)
    {
        if (!_context.Authors.Contains(newAuthor)) throw new ArgumentException("Author doesn't exist!");

        episode.AuthorId = newAuthor.AuthorId;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeNotes(Episode episode, string newNotes)
    {
        episode.Notes = newNotes;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeNumber(Episode episode, int newNumber)
    {
        episode.EpisodeNumber = newNumber;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeSeries(Episode episode, int newSeries)
    {
        episode.SeriesNumber = newSeries;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeDate(Episode episode, DateTime newDate)
    {
        episode.EpisodeDate = newDate;
        _context.SaveChanges();
    }
    
    public void ModifyEpisodeType(Episode episode, string newType)
    {
        episode.EpisodeType = newType;
        _context.SaveChanges();
    }

    public void DeleteEpisode(int episodeId)
    {
        var episodeToDelete = _context.Episodes.FirstOrDefault(e => e.EpisodeId.Equals(episodeId));

        if (episodeToDelete == default)
            throw new Exception($"Episode with id {episodeId} not found!");
        
        _context.Episodes.Remove(episodeToDelete);
        _context.SaveChanges();
    }
    
    public void SummariseEpisodes()
    {
        _context.Database.OpenConnection();
        var cmd = _context.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = "dbo.spSummariseEpisodes";
        var reader = cmd.ExecuteReader();
        var companions = new List<EpisodeSummaryCompanion>();
        var enemies = new List<EpisodeSummaryEnemy>();

        while (reader.Read())
        {
            companions.Add(new EpisodeSummaryCompanion
            {
                CompanionName = reader.GetString("CompanionName"),
                TimesAppeared = reader.GetInt32("TimesAppeared")
            });
        }

        reader.NextResult();

        while (reader.Read())
        {
            enemies.Add(new EpisodeSummaryEnemy
            {
                EnemyName = reader.GetString("EnemyName"),
                TimesAppeared = reader.GetInt32("TimesAppeared")
            });
        }
        reader.Close();
        _context.Database.CloseConnection();

        Console.WriteLine("-------\nCompanion Summary\n-------");
        foreach (var companion in companions)
        {
            Console.WriteLine($"{companion.CompanionName}\n" +
                              $"{companion.TimesAppeared}\n--------");
        }
        
        Console.WriteLine("-------\nEnemy Summary\n-------");
        foreach (var enemy in enemies)
        {
            Console.WriteLine($"{enemy.EnemyName}\n" +
                              $"{enemy.TimesAppeared}\n--------");
        }
    }
    
    public void ListAllEpisodes()
    {
        var episodesWithInfo = _context.EpisodesWithInfo
            .FromSqlRaw("SELECT * FROM dbo.viewEpisodes").ToList();
        foreach (var episode in episodesWithInfo)
        {
            Console.WriteLine($"{episode.AuthorName}\n" +
                              $"{episode.Companions}\n" 
                              + $"{episode.DoctorName}\n-----------");
        }
    }

    public async Task<(IEnumerable<Episode>, PaginationMetadata)> GetEpisodesAsync(int pageNumber, int pageSize)
    {
        var collection = _context.Episodes as IQueryable<Episode>;

        var totalItemCount = await collection.CountAsync();

        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var collectionToReturn = await collection.OrderBy(e => e.SeriesNumber)
            .ThenBy(e => e.EpisodeNumber)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return (collectionToReturn, paginationMetadata);
    }

    public async Task<Episode?> GetEpisodeAsync(int episodeId)
    {
        return await _context.Episodes.FirstOrDefaultAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task<bool> DoctorExistsAsync(int doctorId)
    {
        return await _context.Doctors.AnyAsync(d => d.DoctorId.Equals(doctorId));
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.AuthorId.Equals(authorId));
    }
    
    public async Task AddEpisodeAsync(Episode episode)
    {
        await _context.Episodes.AddAsync(episode);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}