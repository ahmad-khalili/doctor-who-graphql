using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public AuthorRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Author> UpdateAuthorAsync(int authorId, Author author)
    {
        var oldAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId.Equals(authorId));

        oldAuthor!.AuthorName = author.AuthorName;

        return oldAuthor;
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.AuthorId.Equals(authorId));
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}