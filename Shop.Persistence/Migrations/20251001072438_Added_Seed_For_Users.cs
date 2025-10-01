using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Seed_For_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId", "Salt", "UserName" },
                values: new object[] { 1, "admin@gmail.com", "$2a$11$8C7KA1DtqHPEtintkU5aU.HQrnF4kgn4eBJy1Pa1tp7/RHsGnDIfe", 1, "$2a$11$8C7KA1DtqHPEtintkU5aU.", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
