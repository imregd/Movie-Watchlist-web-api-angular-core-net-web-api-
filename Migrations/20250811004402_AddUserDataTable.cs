using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "MovieWatched",
                table: "UserMovies",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserMovies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserData_UserId",
                table: "UserMovies");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMovies");

            migrationBuilder.AlterColumn<string>(
                name: "MovieWatched",
                table: "UserMovies",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }
    }
}
