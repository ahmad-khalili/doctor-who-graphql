using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Ben Aaronovitch" },
                    { 2, "Douglas Adams" },
                    { 3, "David Agnew" },
                    { 4, "Maxine Alderton" },
                    { 5, "Bob Baker" }
                });

            migrationBuilder.InsertData(
                table: "Companion",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Susan Foreman", "Carole Ann Ford" },
                    { 2, "Barbara Wright", "Jacqueline Hill" },
                    { 3, "Ian Chesterton", "William Russell" },
                    { 4, "Vicki", "Maureen O'Brien" },
                    { 5, "Steven Taylor", "Peter Purves" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1908, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Hartnell", 1, new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1966, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1920, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick Troughton", 2, new DateTime(1966, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1968, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1919, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon Pertwee", 3, new DateTime(1968, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1934, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Baker", 4, new DateTime(1976, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1951, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Davison", 5, new DateTime(1982, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemy",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "An old friend, and an old foe, The Master has faced the Doctor throughout several lifecycles", "The Master" },
                    { 2, "Daleks are a perennial threat to our dual-hearted hero, and are the only villain so far to have faced every version of the Doctor", "The Daleks" },
                    { 3, "First introduced way back in 1966, they were a part of the First Doctor William Hartnell''s final serial", "The Cybermen" },
                    { 4, "These menacing looking statue-like humanoids can kill people with a single touch and can only move when they''re not being looked at, including when people blink", "The Weeping Angels" },
                    { 5, "Round, brown, and great with butter, the Sontarans aren’t to be messed with", "Sontarans" }
                });

            migrationBuilder.InsertData(
                table: "Episode",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 3, 5, new DateTime(2005, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Musical", "Happy Christmas!", 1, "The Christmas Invasion" },
                    { 2, 2, 1, new DateTime(2005, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Historical", "History party", 1, "The Unquiet Dead" },
                    { 3, 4, 2, new DateTime(2006, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Adventure", "Earth looks cool", 2, "New Earth" },
                    { 4, 1, 3, new DateTime(2005, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Horror", "Scary episode", 2, "Cold Blood" },
                    { 5, 5, 4, new DateTime(2007, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Action", "Nice CGI", 3, "Time Crash" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanion",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 3, 2 },
                    { 3, 2, 3 },
                    { 4, 1, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 3, 2 },
                    { 3, 2, 3 },
                    { 4, 1, 4 },
                    { 5, 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companion",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companion",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companion",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companion",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companion",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episode",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episode",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episode",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episode",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episode",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 5);
        }
    }
}
