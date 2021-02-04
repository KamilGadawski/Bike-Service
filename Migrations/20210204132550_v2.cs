using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BikeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BikeId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CustomerID",
                table: "Bikes",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Customers_CustomerID",
                table: "Bikes",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Customers_CustomerID",
                table: "Bikes");

            migrationBuilder.DropIndex(
                name: "IX_Bikes_CustomerID",
                table: "Bikes");

            migrationBuilder.AddColumn<Guid>(
                name: "BikeId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BikeId",
                table: "Customers",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
