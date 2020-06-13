using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchApp.DataAccess.Migrations
{
    public partial class companytablechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Company");
        }
    }
}
