using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientesApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DATADENASCIMENTO = table.Column<DateTime>(name: "DATA DE NASCIMENTO", type: "datetime2", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
