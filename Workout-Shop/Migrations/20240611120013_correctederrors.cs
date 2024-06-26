using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout_Shop.Migrations
{
    /// <inheritdoc />
    public partial class correctederrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Plans_MovieId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PlanId",
                table: "OrderItems",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Plans_PlanId",
                table: "OrderItems",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Plans_PlanId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PlanId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Plans_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
