using Microsoft.EntityFrameworkCore.Migrations;

namespace DgBar.Infra.Data.Migrations
{
    public partial class adicionadonumerocomanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroComanda",
                table: "produtos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroComanda",
                table: "produtos");
        }
    }
}
