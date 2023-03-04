using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dictionary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tags_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordsPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstLanguageID = table.Column<int>(type: "int", nullable: false),
                    SecondLanguageID = table.Column<int>(type: "int", nullable: false),
                    FirstWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    AttemptsNumber = table.Column<int>(type: "int", nullable: false),
                    ProblemLevel = table.Column<int>(type: "int", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordsPairs_Languages_FirstLanguageID",
                        column: x => x.FirstLanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WordsPairs_Languages_SecondLanguageID",
                        column: x => x.SecondLanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WordsPairs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionSets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionID = table.Column<int>(type: "int", nullable: false),
                    WordsPairID = table.Column<int>(type: "int", nullable: false),
                    WasShowedOnFirstLang = table.Column<bool>(type: "bit", nullable: false),
                    WasShowedOnSecondLang = table.Column<bool>(type: "bit", nullable: false),
                    WasSuccessfulOnFirstLang = table.Column<bool>(type: "bit", nullable: false),
                    WasSuccessfulOnSecondLang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SessionSets_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSets_WordsPairs_WordsPairID",
                        column: x => x.WordsPairID,
                        principalTable: "WordsPairs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WordsPairTag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false),
                    WordsPairID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsPairTag", x => new { x.TagID, x.WordsPairID });
                    table.ForeignKey(
                        name: "FK_WordsPairTag_Tags_WordsPairID",
                        column: x => x.WordsPairID,
                        principalTable: "Tags",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WordsPairTag_WordsPairs_TagID",
                        column: x => x.TagID,
                        principalTable: "WordsPairs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserID",
                table: "Sessions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSets_SessionID",
                table: "SessionSets",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSets_WordsPairID",
                table: "SessionSets",
                column: "WordsPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserID",
                table: "Tags",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WordsPairs_FirstLanguageID",
                table: "WordsPairs",
                column: "FirstLanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_WordsPairs_SecondLanguageID",
                table: "WordsPairs",
                column: "SecondLanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_WordsPairs_UserID",
                table: "WordsPairs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WordsPairTag_WordsPairID",
                table: "WordsPairTag",
                column: "WordsPairID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionSets");

            migrationBuilder.DropTable(
                name: "WordsPairTag");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "WordsPairs");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
