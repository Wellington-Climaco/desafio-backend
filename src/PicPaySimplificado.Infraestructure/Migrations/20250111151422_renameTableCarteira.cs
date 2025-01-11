using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPaySimplificado.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class renameTableCarteira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Carteiras_PayeerId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Carteiras_ReciverId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carteiras",
                table: "Carteiras");

            migrationBuilder.RenameTable(
                name: "Carteiras",
                newName: "Wallet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Wallet_PayeerId",
                table: "Transaction",
                column: "PayeerId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Wallet_ReciverId",
                table: "Transaction",
                column: "ReciverId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Wallet_PayeerId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Wallet_ReciverId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Carteiras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carteiras",
                table: "Carteiras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Carteiras_PayeerId",
                table: "Transaction",
                column: "PayeerId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Carteiras_ReciverId",
                table: "Transaction",
                column: "ReciverId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
