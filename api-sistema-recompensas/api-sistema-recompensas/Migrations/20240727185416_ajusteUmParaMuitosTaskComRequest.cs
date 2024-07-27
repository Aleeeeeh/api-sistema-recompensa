using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_sistema_recompensas.Migrations
{
    /// <inheritdoc />
    public partial class ajusteUmParaMuitosTaskComRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_TaskId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TaskId",
                table: "Request",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_TaskId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TaskId",
                table: "Request",
                column: "TaskId",
                unique: true);
        }
    }
}
