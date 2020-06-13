using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchApp.DataAccess.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Job",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
