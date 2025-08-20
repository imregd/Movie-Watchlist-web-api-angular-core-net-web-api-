using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Watchlist_web_api__angular___core_net_web_api_.Migrations
{
    /// <inheritdoc />
    public partial class UserMoviesDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserDTO_UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserDTOUserId",
                table: "UserMovies");

            migrationBuilder.CreateTable(
                name: "UserMoviesDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieName = table.Column<string>(type: "TEXT", nullable: false),
                    MovieWatched = table.Column<bool>(type: "INTEGER", nullable: false),
                    MovieRating = table.Column<int>(type: "INTEGER", nullable: true),
                    UserDTOUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMoviesDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMoviesDTO_UserDTO_UserDTOUserId",
                        column: x => x.UserDTOUserId,
                        principalTable: "UserDTO",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMoviesDTO_UserDTOUserId",
                table: "UserMoviesDTO",
                column: "UserDTOUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMoviesDTO");

            migrationBuilder.AddColumn<int>(
                name: "UserDTOUserId",
                table: "UserMovies",
                type: "INTEGER",
                nullable: true);

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
        }
    }
}
