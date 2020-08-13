using Microsoft.EntityFrameworkCore.Migrations;

namespace DgBar.Infra.Data.Migrations
{
    public partial class adicionadocolunasproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "produtos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "produtos");
        }
    }
}
