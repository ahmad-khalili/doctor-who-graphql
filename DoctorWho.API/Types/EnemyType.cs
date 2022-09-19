using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class EnemyType : ObjectGraphType<Enemy>
{
    public EnemyType()
    {
        Field(e => e.EnemyId);
        Field(e => e.EnemyName);
        Field(e => e.Description);
    }
}