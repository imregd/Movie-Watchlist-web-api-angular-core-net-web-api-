using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Migrations
{
    /// <inheritdoc />
    public partial class UserDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserMovies",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMovies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDTOUserId",
                table: "UserMovies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDTO",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserDTOUserId",
                table: "UserMovies",
                column: "UserDTOUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserDTO_UserDTOUserId",
                table: "UserMovies",
                column: "UserDTOUserId",
                principalTable: "UserDTO",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserDTO_UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies");

            migrationBuilder.DropTable(
                name: "UserDTO");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserMovies",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMovies",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }
    }
}
