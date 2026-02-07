using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingBuddy.Migrations
{
    /// <inheritdoc />
    public partial class MakeStoreIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_Stores_StoreId",
                table: "ShoppingItems");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ShoppingItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_Stores_StoreId",
                table: "ShoppingItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_Stores_StoreId",
                table: "ShoppingItems");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ShoppingItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_Stores_StoreId",
                table: "ShoppingItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
