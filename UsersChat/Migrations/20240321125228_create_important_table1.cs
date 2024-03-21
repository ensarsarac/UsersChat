using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersChat.Migrations
{
    public partial class create_important_table1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Important_UserMessages_UserMessageID",
                table: "Important");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Important",
                table: "Important");

            migrationBuilder.RenameTable(
                name: "Important",
                newName: "Importants");

            migrationBuilder.RenameIndex(
                name: "IX_Important_UserMessageID",
                table: "Importants",
                newName: "IX_Importants_UserMessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Importants",
                table: "Importants",
                column: "ImportantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Importants_UserMessages_UserMessageID",
                table: "Importants",
                column: "UserMessageID",
                principalTable: "UserMessages",
                principalColumn: "UserMessageID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Importants_UserMessages_UserMessageID",
                table: "Importants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Importants",
                table: "Importants");

            migrationBuilder.RenameTable(
                name: "Importants",
                newName: "Important");

            migrationBuilder.RenameIndex(
                name: "IX_Importants_UserMessageID",
                table: "Important",
                newName: "IX_Important_UserMessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Important",
                table: "Important",
                column: "ImportantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Important_UserMessages_UserMessageID",
                table: "Important",
                column: "UserMessageID",
                principalTable: "UserMessages",
                principalColumn: "UserMessageID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
