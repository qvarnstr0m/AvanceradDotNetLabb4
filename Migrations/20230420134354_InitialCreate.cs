using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvanceradDotNetLabb4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestsPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkInterestId = table.Column<int>(type: "int", nullable: true),
                    FkPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestsPersons_Interests_FkInterestId",
                        column: x => x.FkInterestId,
                        principalTable: "Interests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterestsPersons_Persons_FkPersonId",
                        column: x => x.FkPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkInterestPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_InterestsPersons_FkInterestPersonId",
                        column: x => x.FkInterestPersonId,
                        principalTable: "InterestsPersons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestsPersons_FkInterestId",
                table: "InterestsPersons",
                column: "FkInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsPersons_FkPersonId",
                table: "InterestsPersons",
                column: "FkPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FkInterestPersonId",
                table: "Links",
                column: "FkInterestPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "InterestsPersons");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
