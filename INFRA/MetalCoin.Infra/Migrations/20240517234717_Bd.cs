using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetalCoin.Infra.Migrations
{
    public partial class Bd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoCupom = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal", nullable: false),
                    QtdCuponsLiberados = table.Column<int>(type: "int", nullable: false),
                    QtdCuponsUsados = table.Column<int>(type: "int", nullable: false),
                    TipoDesconto = table.Column<string>(type: "varchar(100)", nullable: false),
                    StatusCupom = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupons");
        }
    }
}
