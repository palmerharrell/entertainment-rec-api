using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaAPI.Migrations
{
    public partial class AddLightAndDarkColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "MediaType");

            migrationBuilder.AddColumn<string>(
                name: "ColorDark",
                table: "MediaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorLight",
                table: "MediaType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorDark",
                table: "MediaType");

            migrationBuilder.DropColumn(
                name: "ColorLight",
                table: "MediaType");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "MediaType",
                nullable: true);
        }
    }
}
