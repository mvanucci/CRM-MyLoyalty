using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class fix_pesquisa_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "atendimento",
                table: "Pesquisa",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "accProduto",
                table: "Pesquisa",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "atendimento",
                table: "Pesquisa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "accProduto",
                table: "Pesquisa",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
