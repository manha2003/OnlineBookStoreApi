using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrderId",
                table: "Users",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
