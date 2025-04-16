using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Order_Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_Id",
                schema: "evaluation",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Company_Id",
                schema: "evaluation",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                schema: "evaluation",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductId",
                schema: "evaluation",
                table: "OrderProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "evaluation",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "evaluation",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "evaluation",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "evaluation",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "evaluation",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "evaluation",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                schema: "evaluation",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_Id",
                schema: "evaluation",
                table: "Order",
                column: "Id",
                principalSchema: "evaluation",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Company_Id",
                schema: "evaluation",
                table: "Order",
                column: "Id",
                principalSchema: "evaluation",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                schema: "evaluation",
                table: "OrderProduct",
                column: "ProductId",
                principalSchema: "evaluation",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
