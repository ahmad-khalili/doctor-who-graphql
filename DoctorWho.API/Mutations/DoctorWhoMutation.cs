using DoctorWho.API.Types;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using GraphQL;
using GraphQL.Types;

namespace DoctorWho.API.Mutations;

public sealed class DoctorWhoMutation : ObjectGraphType
{
    public DoctorWhoMutation()
    {
        Field<DoctorType>("upsertDoctor").Argument<DoctorInputType>("doctor")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices.GetRequiredService<IDoctorRepository>();
                var doctorToAdd = await context.GetValidatedArgumentAsync<Doctor>("doctor");
                var addedDoctorId = await repository.UpsertDoctorAsync(doctorToAdd);
                doctorToAdd.DoctorId = addedDoctorId;
                return doctorToAdd;
            });
    }
}