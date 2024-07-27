using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_sistema_recompensas.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNomeColunaDataAlteracaoRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Request",
                newName: "UpdateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Request",
                newName: "ApprovalDate");
        }
    }
}
