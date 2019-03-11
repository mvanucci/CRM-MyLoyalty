using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLoyalty.Migrations
{
    public partial class fix_pesquisa_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisa_Cliente_clienteid",
                table: "Pesquisa");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Pesquisa",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pesquisa_clienteid",
                table: "Pesquisa",
                newName: "IX_Pesquisa_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pesquisa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pdtEncontrado",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisa_Cliente_ClienteId",
                table: "Pesquisa",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisa_Cliente_ClienteId",
                table: "Pesquisa");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pesquisa",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Pesquisa_ClienteId",
                table: "Pesquisa",
                newName: "IX_Pesquisa_clienteid");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Pesquisa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "pdtEncontrado",
                table: "Cliente",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisa_Cliente_clienteid",
                table: "Pesquisa",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
