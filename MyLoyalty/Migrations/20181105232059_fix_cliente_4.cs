using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class fix_cliente_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente");


            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "pesquisaid",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productoid",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_pesquisaid",
                table: "Cliente",
                column: "pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
