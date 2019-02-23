using Microsoft.EntityFrameworkCore.Migrations;

namespace Edufund.Data.Migrations
{
    public partial class addedUserToMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EduUserId",
                table: "Member",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_EduUserId",
                table: "Member",
                column: "EduUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_AspNetUsers_EduUserId",
                table: "Member",
                column: "EduUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_AspNetUsers_EduUserId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_EduUserId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "EduUserId",
                table: "Member");
        }
    }
}
