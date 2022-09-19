using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories;

public interface IAuthorRepository
{
    Task<Author?> GetAuthorAsync(int authorId);
    Task<bool> SaveChangesAsync();
}