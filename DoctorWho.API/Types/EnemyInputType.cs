using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class EnemyInputType : InputObjectGraphType<Enemy>
{
    public EnemyInputType()
    {
        Field(e => e.EnemyName);
        Field(e => e.Description);
    }
}