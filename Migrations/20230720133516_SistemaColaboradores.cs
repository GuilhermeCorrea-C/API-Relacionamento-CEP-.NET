using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRelacionamento.Migrations
{
    public partial class SistemaColaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoCep",
                columns: table => new
                {
                    Cep = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ibge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Siafi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoCep", x => x.Cep);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    idColaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CepColaborador = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.idColaborador);
                    table.ForeignKey(
                        name: "FK_Colaboradores_InfoCep_CepColaborador",
                        column: x => x.CepColaborador,
                        principalTable: "InfoCep",
                        principalColumn: "Cep",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "idColaborador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_CepColaborador",
                table: "Colaboradores",
                column: "CepColaborador");

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

            migrationBuilder.DropTable(
                name: "InfoCep");
        }
    }
}
