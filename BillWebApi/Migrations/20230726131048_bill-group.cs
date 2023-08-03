using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWebApi.Migrations
{
    /// <inheritdoc />
    public partial class billgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GroupId", "Password" },
                values: new object[] { null, "$2a$11$nZ8sYFy6jKWx27BBlbT7vO3xVDJ4ikdzCAidbuA6S0.sSGZdA/6a2" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_GroupId",
                table: "Bills",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Groups_GroupId",
                table: "Bills",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Groups_GroupId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Bills_GroupId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Bills");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$S6actJXan1h3Mc0xVftMY.DyjSgiMf0w0j.j9dGd5J0tIq1EJROlG");
        }
    }
}
