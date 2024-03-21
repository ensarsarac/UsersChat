using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersChat.Migrations
{
    public partial class add_trash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trashes",
                columns: table => new
                {
                    TrashID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trashes", x => x.TrashID);
                    table.ForeignKey(
                        name: "FK_Trashes_UserMessages_UserMessageID",
                        column: x => x.UserMessageID,
                        principalTable: "UserMessages",
                        principalColumn: "UserMessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trashes_UserMessageID",
                table: "Trashes",
                column: "UserMessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trashes");
        }
    }
}
