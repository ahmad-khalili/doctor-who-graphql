using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class Procedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"CREATE FUNCTION fnCompanions (@EpisodeId int)
									RETURNS varchar(MAX) AS
									BEGIN
										DECLARE @companions varchar(MAX);
										SELECT @companions = CONCAT(@companions + ', ', c.CompanionName)
										FROM {nameof(Companion)} c
										INNER JOIN {nameof(EpisodeCompanion)} ec ON ec.CompanionId = c.CompanionId
										WHERE ec.EpisodeId = @EpisodeId
										RETURN @companions;
									END");

            migrationBuilder.Sql(@$"CREATE FUNCTION fnEnemies (@EpisodeId int)
									RETURNS varchar(MAX) AS
									BEGIN
										DECLARE @enemies varchar(MAX);
										SELECT @enemies = CONCAT(@enemies + ', ', e.EnemyName)
										FROM {nameof(Enemy)} e
										INNER JOIN {nameof(EpisodeEnemy)} ee ON ee.EnemyId = e.EnemyId
										WHERE ee.EpisodeId = @EpisodeId
										RETURN @enemies
									END");

            migrationBuilder.Sql(@$"CREATE VIEW viewEpisodes AS
									SELECT a.AuthorName, d.DoctorName, dbo.fnCompanions(e.EpisodeId)
									AS Companions, dbo.fnEnemies(e.EpisodeId) AS Enemies
									FROM {nameof(Episode)} e, {nameof(Author)} a, {nameof(Doctor)} d
									WHERE e.AuthorId = a.AuthorId AND e.DoctorId = d.DoctorId;");

            migrationBuilder.Sql(@$"CREATE PROCEDURE spSummariseEpisodes AS
									BEGIN
										SELECT TOP 3 c.CompanionName, COUNT(ec.CompanionId) AS TimesAppeared
										FROM {nameof(EpisodeCompanion)} ec, {nameof(Companion)} c
										WHERE c.CompanionId = ec.CompanionId
										GROUP BY c.CompanionName
										ORDER BY TimesAppeared DESC;
									END;
									BEGIN
										SELECT TOP 3 e.EnemyName, COUNT(ee.EnemyId) AS TimesAppeared
										FROM {nameof(EpisodeEnemy)} ee, {nameof(Enemy)} e
										WHERE e.EnemyId = ee.EnemyId
										GROUP BY e.EnemyName
										ORDER BY TimesAppeared DESC
									END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP FUNCTION dbo.fnCompanions");
	        migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemies");
	        migrationBuilder.Sql("DROP VIEW dbo.viewEpisodes");
	        migrationBuilder.Sql("DROP PROCEDURE dbo.spSummariseEpisodes");
        }
    }
}
