using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchApp.DataAccess.Migrations
{
    public partial class MappedJobToCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Job",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyId",
                table: "Job",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CompanyId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Job");
        }
    }
}
