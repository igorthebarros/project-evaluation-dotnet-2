using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Company_Inside_Address_ToBe_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Company_CompanyId1",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId1",
                schema: "evaluation",
                table: "Address",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Company_CompanyId1",
                schema: "evaluation",
                table: "Address",
                column: "CompanyId1",
                principalSchema: "evaluation",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Company_CompanyId1",
                schema: "evaluation",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId1",
                schema: "evaluation",
                table: "Address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
