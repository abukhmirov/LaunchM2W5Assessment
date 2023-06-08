using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace M2W5Assessment.Migrations
{
    public partial class AddPerformersAndManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "performer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    genre = table.Column<string>(type: "text", nullable: false),
                    members = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_performer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "concert_performer",
                columns: table => new
                {
                    attending_concerts_id = table.Column<int>(type: "integer", nullable: false),
                    performers_attending_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concert_performer", x => new { x.attending_concerts_id, x.performers_attending_id });
                    table.ForeignKey(
                        name: "fk_concert_performer_concerts_attending_concerts_id",
                        column: x => x.attending_concerts_id,
                        principalTable: "concerts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_concert_performer_performer_performers_attending_id",
                        column: x => x.performers_attending_id,
                        principalTable: "performer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_concert_performer_performers_attending_id",
                table: "concert_performer",
                column: "performers_attending_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concert_performer");

            migrationBuilder.DropTable(
                name: "performer");
        }
    }
}
