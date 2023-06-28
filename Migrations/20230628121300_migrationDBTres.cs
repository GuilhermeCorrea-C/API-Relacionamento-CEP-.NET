using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRelacionamento.Migrations
{
    public partial class migrationDBTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    idColaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    salario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.idColaborador);
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    idDependente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    idColaborador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.idDependente);
                    table.ForeignKey(
                        name: "FK_Dependentes_Colaboradores_idColaborador",
                        column: x => x.idColaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "idColaborador");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_idColaborador",
                table: "Dependentes",
                column: "idColaborador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
