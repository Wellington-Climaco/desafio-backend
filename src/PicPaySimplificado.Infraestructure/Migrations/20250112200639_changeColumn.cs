using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPaySimplificado.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class changeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeWalltet",
                table: "Wallet",
                newName: "TypeWallet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeWallet",
                table: "Wallet",
                newName: "TypeWalltet");
        }
    }
}
