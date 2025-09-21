using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class New_Seed_For_Permissons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "افزودن کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "ویرایش کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "حذف کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "مشاهده کاربران");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "افزودن دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "ویرایش دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "حذف دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "مشاهده دسته‌بندی‌ها");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Title",
                value: "افزودن محصول");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Title",
                value: "ویرایش محصول");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "حذف محصول");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "مشاهده محصولات");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "مشاهده کاربران");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "ایجاد کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "ویرایش کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "حذف کاربر");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "مشاهده دسته‌بندی‌ها");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "ایجاد دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "ویرایش دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "حذف دسته‌بندی");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Title",
                value: "مشاهده محصولات");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Title",
                value: "ایجاد محصول");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "ویرایش محصول");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "حذف محصول");
        }
    }
}
