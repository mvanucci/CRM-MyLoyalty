using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class fix_pesquisa_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Pesquisaid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Pesquisaid",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "Pesquisa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisa_clienteid",
                table: "Pesquisa",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisa_Cliente_clienteid",
                table: "Pesquisa",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisa_Cliente_clienteid",
                table: "Pesquisa");

            migrationBuilder.DropIndex(
                name: "IX_Pesquisa_clienteid",
                table: "Pesquisa");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "Pesquisa");

            migrationBuilder.AddColumn<int>(
                name: "Pesquisaid",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Pesquisaid",
                table: "Cliente",
                column: "Pesquisaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente",
                column: "Pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
