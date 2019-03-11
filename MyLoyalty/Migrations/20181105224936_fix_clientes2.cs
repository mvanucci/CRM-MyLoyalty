using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class fix_clientes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Cliente_clienteid",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_clienteid",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "Produto");

            

            migrationBuilder.AddColumn<int>(
                name: "produtoid",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_produtoid",
                table: "Cliente",
                column: "produtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Produto_produtoid",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_produtoid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "produtoid",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_clienteid",
                table: "Produto",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Cliente_clienteid",
                table: "Produto",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
