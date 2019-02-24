using Microsoft.EntityFrameworkCore.Migrations;

namespace Edufund.Data.Migrations
{
    public partial class addentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "AspNetRoles", columns: new[] { "Name", "NormalizedName" }, values: new object[] { "Administrator", "Administrator".ToUpper() });
            migrationBuilder.InsertData(table: "AspNetRoles", columns: new[] { "Name", "NormalizedName" }, values: new object[] { "Support" , "Support".ToUpper()});
            migrationBuilder.InsertData(table: "AspNetRoles", columns: new[] { "Name", "NormalizedName" }, values: new object[] { "Member", "Member".ToUpper() });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
