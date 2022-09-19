using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IAuthorRepository
{
    Task<Author> UpdateAuthorAsync(int authorId, Author author);
    Task<bool> AuthorExistsAsync(int authorId);
    Task<bool> SaveChangesAsync();
}