using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class cliente_fix_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "pesquisaid",
                table: "Cliente",
                newName: "Pesquisaid");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_pesquisaid",
                table: "Cliente",
                newName: "IX_Cliente_Pesquisaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente",
                column: "Pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Pesquisaid",
                table: "Cliente",
                newName: "pesquisaid");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_Pesquisaid",
                table: "Cliente",
                newName: "IX_Cliente_pesquisaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente",
                column: "pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
