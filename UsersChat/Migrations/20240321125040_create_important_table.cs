using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersChat.Migrations
{
    public partial class create_important_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Important",
                columns: table => new
                {
                    ImportantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Important", x => x.ImportantID);
                    table.ForeignKey(
                        name: "FK_Important_UserMessages_UserMessageID",
                        column: x => x.UserMessageID,
                        principalTable: "UserMessages",
                        principalColumn: "UserMessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Important_UserMessageID",
                table: "Important",
                column: "UserMessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Important");
        }
    }
}
