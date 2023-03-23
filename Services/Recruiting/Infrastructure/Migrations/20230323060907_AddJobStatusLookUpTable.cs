using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJobStatusLookUpTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobStatusLookUpId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobStatusLookUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusLookUps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId",
                principalTable: "JobStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobStatusLookUps");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobStatusLookUpId",
                table: "Jobs");
        }
    }
}
