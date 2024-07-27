using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_sistema_recompensas.Migrations
{
    /// <inheritdoc />
    public partial class retirandoObrigatoriedadeUsuarioRequest : Migration
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

            migrationBuilder.AlterColumn<long>(
                name: "UserIdRequester",
                table: "Request",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserIdApprover",
                table: "Request",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request");

            migrationBuilder.AlterColumn<long>(
                name: "UserIdRequester",
                table: "Request",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserIdApprover",
                table: "Request",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdApprover",
                table: "Request",
                column: "UserIdApprover",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdRequester",
                table: "Request",
                column: "UserIdRequester",
                unique: true);
        }
    }
}
