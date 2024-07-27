using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_sistema_recompensas.Migrations
{
    /// <inheritdoc />
    public partial class ajusteUmParaMuitosUserComRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request",
                column: "UserIdApprover");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request",
                column: "UserIdRequester");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request",
                column: "UserIdApprover",
                unique: true,
                filter: "[UserIdApprover] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request",
                column: "UserIdRequester",
                unique: true,
                filter: "[UserIdRequester] IS NOT NULL");
        }
    }
}
