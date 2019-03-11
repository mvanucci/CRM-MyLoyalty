using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class cliente_pk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "pesquisaid",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente",
                column: "pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "pesquisaid",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(int));

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
