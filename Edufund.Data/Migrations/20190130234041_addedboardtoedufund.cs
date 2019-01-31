using Microsoft.EntityFrameworkCore.Migrations;

namespace Edufund.Data.Migrations
{
    public partial class addedboardtoedufund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduFundSystem_Board_BoardId",
                table: "EduFundSystem");

            migrationBuilder.DropIndex(
                name: "IX_EduFundSystem_BoardId",
                table: "EduFundSystem");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "EduFundSystem");

            migrationBuilder.AddColumn<int>(
                name: "EduFundSystemId",
                table: "Board",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Board_EduFundSystemId",
                table: "Board",
                column: "EduFundSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_EduFundSystem_EduFundSystemId",
                table: "Board",
                column: "EduFundSystemId",
                principalTable: "EduFundSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_EduFundSystem_EduFundSystemId",
                table: "Board");

            migrationBuilder.DropIndex(
                name: "IX_Board_EduFundSystemId",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "EduFundSystemId",
                table: "Board");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "EduFundSystem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EduFundSystem_BoardId",
                table: "EduFundSystem",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_EduFundSystem_Board_BoardId",
                table: "EduFundSystem",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
