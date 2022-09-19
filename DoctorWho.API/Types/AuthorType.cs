using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class AuthorType : ObjectGraphType<Author>
{
    public AuthorType()
    {
        Field(a => a.AuthorId);
        Field(a => a.AuthorName);
    }
}