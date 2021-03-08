using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class updateBikeModelFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedBike = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "AddedBike", "Brand", "CustomerID", "Description", "Model", "Size" },
                values: new object[,]
                {
                    { new Guid("d719c835-ce3e-4dad-ad64-cfec54b19775"), new DateTime(2020, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giant", new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"), "Repair front wheel", "TCR", 54 },
                    { new Guid("e6e46660-bb84-451d-aafe-a6c7346a48ae"), new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kross", new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"), "Change Casette", "Vento 5.0", 58 },
                    { new Guid("99289c1a-3342-40fc-905b-65c2dd59babe"), new DateTime(2020, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merida", new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"), "Change chain", "Reacto 4000", 56 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateTimeAdd", "Edit", "Email", "Name", "Surname", "TelephoneNumber" },
                values: new object[,]
                {
                    { new Guid("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"), new DateTime(2020, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@gmail.com", "Johon", "Wallie", "123456789" },
                    { new Guid("3c7ddfb9-cfb4-4b97-a95a-8510ecb707d1"), new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark@gmail.com", "Mark", "Tree", "234567891" },
                    { new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"), new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@gmail.com", "Peter", "Kowalsky", "434567891" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
