using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPaySimplificado.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Carteiras",
                newName: "TypeWalltet");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Carteiras",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Carteiras",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Carteiras",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Carteiras",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    PayeerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReciverId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Carteiras_PayeerId",
                        column: x => x.PayeerId,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Carteiras_ReciverId",
                        column: x => x.ReciverId,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PayeerId",
                table: "Transaction",
                column: "PayeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReciverId",
                table: "Transaction",
                column: "ReciverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Carteiras");

            migrationBuilder.RenameColumn(
                name: "TypeWalltet",
                table: "Carteiras",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Carteiras",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Carteiras",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Carteiras",
                newName: "Saldo");
        }
    }
}
