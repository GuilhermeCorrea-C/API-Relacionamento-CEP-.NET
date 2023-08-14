using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRelacionamento.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependentes_Colaboradores_idColaborador",
                table: "Dependentes");

            migrationBuilder.RenameColumn(
                name: "idColaborador",
                table: "Dependentes",
                newName: "ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Dependentes_idColaborador",
                table: "Dependentes",
                newName: "IX_Dependentes_ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependentes_Colaboradores_ColaboradorId",
                table: "Dependentes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "idColaborador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependentes_Colaboradores_ColaboradorId",
                table: "Dependentes");

            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "Dependentes",
                newName: "idColaborador");

            migrationBuilder.RenameIndex(
                name: "IX_Dependentes_ColaboradorId",
                table: "Dependentes",
                newName: "IX_Dependentes_idColaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependentes_Colaboradores_idColaborador",
                table: "Dependentes",
                column: "idColaborador",
                principalTable: "Colaboradores",
                principalColumn: "idColaborador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
