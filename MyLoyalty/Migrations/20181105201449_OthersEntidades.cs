using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class OthersEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pesquisaid",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pesquisa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    atendimento = table.Column<string>(nullable: true),
                    notaVendedor = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    accProduto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    codigo = table.Column<int>(nullable: false),
                    cor = table.Column<string>(nullable: true),
                    tamanho = table.Column<int>(nullable: false),
                    genero = table.Column<string>(nullable: true),
                    estoque = table.Column<int>(nullable: false),
                    clienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Pesquisaid",
                table: "Cliente",
                column: "Pesquisaid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_clienteid",
                table: "Cliente",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_clienteid",
                table: "Produto",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente",
                column: "Pesquisaid",
                principalTable: "Pesquisa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cliente_clienteid",
                table: "Cliente",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pesquisa_Pesquisaid",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cliente_clienteid",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Pesquisa");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Pesquisaid",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_clienteid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Pesquisaid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "Cliente");
        }
    }
}
