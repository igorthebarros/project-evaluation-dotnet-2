using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_On_Address_CompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "evaluation",
                table: "Address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                schema: "evaluation",
                table: "Address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                schema: "evaluation",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId1",
                schema: "evaluation",
                table: "Address",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Company_CompanyId",
                schema: "evaluation",
                table: "Address",
                column: "CompanyId",
                principalSchema: "evaluation",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Company_CompanyId1",
                schema: "evaluation",
                table: "Address",
                column: "CompanyId1",
                principalSchema: "evaluation",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Company_CompanyId",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Company_CompanyId1",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CompanyId",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CompanyId1",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                schema: "evaluation",
                table: "Address");
        }
    }
}
