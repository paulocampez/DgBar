using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DgBar.Infra.Data.Migrations
{
    public partial class adicionadoComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ComandaId",
                table: "produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "comandas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comandas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_produtos_ComandaId",
                table: "produtos",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_comandas_ComandaId",
                table: "produtos",
                column: "ComandaId",
                principalTable: "comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_comandas_ComandaId",
                table: "produtos");

            migrationBuilder.DropTable(
                name: "comandas");

            migrationBuilder.DropIndex(
                name: "IX_produtos_ComandaId",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "produtos");
        }
    }
}
