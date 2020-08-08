using Microsoft.EntityFrameworkCore.Migrations;

namespace DgBar.Infra.Data.Migrations
{
    public partial class ImplementadoColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "produtos");
        }
    }
}
