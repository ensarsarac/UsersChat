using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersChat.Migrations
{
    public partial class add_draft_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    DraftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserID = table.Column<int>(type: "int", nullable: false),
                    ReceiveUserID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.DraftID);
                    table.ForeignKey(
                        name: "FK_Drafts_AspNetUsers_ReceiveUserID",
                        column: x => x.ReceiveUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drafts_AspNetUsers_SenderUserID",
                        column: x => x.SenderUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_ReceiveUserID",
                table: "Drafts",
                column: "ReceiveUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_SenderUserID",
                table: "Drafts",
                column: "SenderUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drafts");
        }
    }
}
