using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediaAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    IdAppUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.IdAppUser);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    IdMediaType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.IdMediaType);
                });

            migrationBuilder.CreateTable(
                name: "MediaItem",
                columns: table => new
                {
                    IdMediaItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    IdAppUser = table.Column<int>(nullable: false),
                    IdMediaType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Recommender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItem", x => x.IdMediaItem);
                    table.ForeignKey(
                        name: "FK_MediaItem_AppUser_IdAppUser",
                        column: x => x.IdAppUser,
                        principalTable: "AppUser",
                        principalColumn: "IdAppUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaItem_MediaType_IdMediaType",
                        column: x => x.IdMediaType,
                        principalTable: "MediaType",
                        principalColumn: "IdMediaType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaItem_IdAppUser",
                table: "MediaItem",
                column: "IdAppUser");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItem_IdMediaType",
                table: "MediaItem",
                column: "IdMediaType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaItem");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "MediaType");
        }
    }
}
