using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserCarts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ProductDiscounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CartItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedAt",
                table: "Users",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_DeletedAt",
                table: "UserRoles",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_DeletedAt",
                table: "UserCarts",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedAt",
                table: "Products",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscounts_DeletedAt",
                table: "ProductDiscounts",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_DeletedAt",
                table: "ProductCategories",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeletedAt",
                table: "Orders",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DeletedAt",
                table: "OrderItems",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_DeletedAt",
                table: "CartItems",
                column: "DeletedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_DeletedAt",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_DeletedAt",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserCarts_DeletedAt",
                table: "UserCarts");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedAt",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductDiscounts_DeletedAt",
                table: "ProductDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_DeletedAt",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeletedAt",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_DeletedAt",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_DeletedAt",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProductDiscounts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CartItems");
        }
    }
}
