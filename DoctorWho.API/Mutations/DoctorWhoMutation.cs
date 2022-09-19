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
                var repository = context.RequestServices!.GetRequiredService<IDoctorRepository>();
                var doctorToAdd = await context.GetValidatedArgumentAsync<Doctor>("doctor");
                var addedDoctorId = await repository.UpsertDoctorAsync(doctorToAdd);
                doctorToAdd.DoctorId = addedDoctorId;
                return doctorToAdd;
            });

        Field<DoctorType>("deleteDoctor").Argument<IntGraphType>("id")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<IDoctorRepository>();
                var doctorId = await context.GetValidatedArgumentAsync<int>("id");
                var doctorEntity = await repository.GetDoctorAsync(doctorId);

                if (doctorEntity == default)
                    throw new ExecutionError($"Doctor with id {doctorId} not found");

                repository.DeleteDoctor(doctorEntity);

                await repository.SaveChangesAsync();

                return doctorEntity;
            });

        Field<EpisodeType>("createEpisode").Argument<EpisodeInputType>("episode")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<IEpisodeRepository>();
                var episodeToAdd = await context.GetValidatedArgumentAsync<Episode>("episode");
                
                if (!await repository.AuthorExistsAsync(episodeToAdd.AuthorId) ||
                    !await repository.DoctorExistsAsync(episodeToAdd.DoctorId))
                    throw new ExecutionError("Doctor or Author IDs don't exist");

                await repository.AddEpisodeAsync(episodeToAdd);

                await repository.SaveChangesAsync();

                return episodeToAdd;
            });
    }
}