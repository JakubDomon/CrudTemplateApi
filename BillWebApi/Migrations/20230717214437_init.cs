using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    addedById = table.Column<int>(type: "int", nullable: false),
                    addDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Users_addedById",
                        column: x => x.addedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillsUsersCash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    UserIDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillsUsersCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillsUsersCash_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillsUsersCash_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Surname" },
                values: new object[] { 1, "Jakub", "$2a$11$S6actJXan1h3Mc0xVftMY.DyjSgiMf0w0j.j9dGd5J0tIq1EJROlG", "Domoń" });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_addedById",
                table: "Bills",
                column: "addedById");

            migrationBuilder.CreateIndex(
                name: "IX_BillsUsersCash_BillId",
                table: "BillsUsersCash",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillsUsersCash_UserIDId",
                table: "BillsUsersCash",
                column: "UserIDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillsUsersCash");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
