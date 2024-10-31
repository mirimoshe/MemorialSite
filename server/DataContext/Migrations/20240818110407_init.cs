using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeceasdsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    First_name = table.Column<string>(type: "text", nullable: false),
                    Last_name = table.Column<string>(type: "text", nullable: false),
                    Birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hometown = table.Column<string>(type: "text", nullable: true),
                    Burial_location = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Images = table.Column<string>(type: "text", nullable: true),
                    Death_detailes = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeceasdsDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false),
                    Identified_number = table.Column<int>(type: "integer", nullable: false),
                    Reported_number = table.Column<int>(type: "integer", nullable: false),
                    StoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    Relation_type = table.Column<string>(type: "text", nullable: false),
                    Story = table.Column<string>(type: "text", nullable: false),
                    Email_for_messages = table.Column<string>(type: "text", nullable: false),
                    Likes_number = table.Column<int>(type: "integer", nullable: false),
                    Reported_number = table.Column<int>(type: "integer", nullable: false),
                    Favorite_number = table.Column<int>(type: "integer", nullable: false),
                    Empowering_number = table.Column<int>(type: "integer", nullable: false),
                    Exciting_number = table.Column<int>(type: "integer", nullable: false),
                    Heroism_number = table.Column<int>(type: "integer", nullable: false),
                    Thanksgiving_number = table.Column<int>(type: "integer", nullable: false),
                    DeceasdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id_person = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Amount_stories = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeceasdsDetails");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
