using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class AuthorInputType : InputObjectGraphType<Author>
{
    public AuthorInputType()
    {
        Field(a => a.AuthorName);
    }
}