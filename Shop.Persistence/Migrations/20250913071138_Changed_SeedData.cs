using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Changed_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "لوازم ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "لوازم خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "موبایل و تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "لپ‌تاپ و لوازم جانبی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "کامپیوتر و قطعات");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "پوشاک و مد" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "توپ حرفه‌ای فوتبال سایز ۵", "توپ فوتبال", 350000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 2, 1, "کفش مخصوص دویدن", true, "کفش ورزشی نایک", 2200000m },
                    { 3, 1, "ست دمبل مناسب بدنسازی", true, "دمبل ۱۰ کیلویی", 800000m },
                    { 4, 1, "طناب مناسب برای تمرین هوازی", true, "طناب ورزشی", 150000m },
                    { 5, 1, "تشک مخصوص حرکات یوگا و پیلاتس", true, "تشک یوگا", 300000m },
                    { 6, 1, "دستکش ورزشی ضدلغزش", true, "دستکش بدنسازی", 180000m },
                    { 7, 1, "دوچرخه ثابت خانگی", true, "دوچرخه ثابت", 5500000m },
                    { 8, 1, "ست کش تمرینی چندکاره", true, "کش مقاومتی", 250000m },
                    { 9, 1, "کیسه بوکس ایستاده", true, "کیسه بوکس", 1800000m },
                    { 10, 1, "ست تیشرت و شلوار ورزشی", true, "لباس ورزشی", 400000m },
                    { 11, 2, "یخچال فریزر دو قلو سامسونگ", true, "یخچال فریزر", 35000000m },
                    { 12, 2, "لباسشویی اتوماتیک ۸ کیلویی", true, "ماشین لباسشویی", 18000000m },
                    { 13, 2, "مایکروویو ۴۰ لیتری", true, "مایکروویو", 7500000m },
                    { 14, 2, "جاروبرقی ۲۲۰۰ وات", true, "جاروبرقی", 4500000m },
                    { 15, 2, "پنکه پرقدرت ۳ سرعته", true, "پنکه ایستاده", 1200000m },
                    { 16, 2, "غذا ساز چندکاره", true, "غذا ساز", 3800000m },
                    { 17, 2, "اتو بخار حرفه‌ای", true, "اتو بخار", 900000m },
                    { 18, 2, "کتری برقی استیل ۲ لیتری", true, "کتری برقی", 600000m },
                    { 19, 2, "قهوه‌ساز فیلیپس", true, "قهوه‌ساز", 4200000m },
                    { 20, 2, "ظرفشویی ۱۴ نفره بوش", true, "ماشین ظرفشویی", 25000000m },
                    { 21, 3, "گوشی اپل آیفون 14 پرو مکس", true, "آیفون 14", 65000000m },
                    { 22, 3, "گوشی سامسونگ گلکسی S23", true, "سامسونگ S23", 48000000m },
                    { 23, 3, "گوشی شیائومی سری ۱۳", true, "شیائومی 13", 25000000m },
                    { 24, 3, "تبلت اپل آیپد پرو ۱۲ اینچ", true, "تبلت آیپد پرو", 58000000m },
                    { 25, 3, "تبلت اندرویدی سامسونگ", true, "تبلت سامسونگ Tab S9", 30000000m },
                    { 26, 3, "شارژر اصل USB-C", true, "شارژر سریع ۶۵ وات", 900000m },
                    { 27, 3, "ایرفون بی‌سیم", true, "ایرفون بلوتوث", 1500000m },
                    { 28, 3, "کاور ضد ضربه سیلیکونی", true, "کاور گوشی", 250000m },
                    { 29, 3, "گلس ضدخش", true, "محافظ صفحه", 200000m },
                    { 30, 3, "پاوربانک شیائومی", true, "پاوربانک ۲۰۰۰۰", 1600000m },
                    { 31, 4, "لپ‌تاپ گیمینگ ایسوس", true, "لپ‌تاپ ایسوس", 42000000m },
                    { 32, 4, "لپ‌تاپ اداری دل", true, "لپ‌تاپ دل", 28000000m },
                    { 33, 4, "مک‌بوک پرو ۱۴ اینچ", true, "لپ‌تاپ اپل مک‌بوک", 70000000m },
                    { 34, 4, "موس RGB گیمینگ", true, "موس گیمینگ", 1200000m },
                    { 35, 4, "کیبورد مکانیکال RGB", true, "کیبورد مکانیکال", 1800000m },
                    { 36, 4, "کوله ضد ضربه لپ‌تاپ", true, "کوله لپ‌تاپ", 900000m },
                    { 37, 4, "کول‌پد لپ‌تاپ", true, "پایه خنک‌کننده", 800000m },
                    { 38, 4, "وب‌کم HD مناسب تماس تصویری", true, "وب‌کم", 1500000m },
                    { 39, 4, "هدست با میکروفون", true, "هدست گیمینگ", 2200000m },
                    { 40, 4, "هارد اکسترنال ۱ ترابایت", true, "هارد اکسترنال", 2500000m },
                    { 41, 5, "کارت گرافیک انویدیا", true, "کارت گرافیک RTX 4070", 60000000m },
                    { 42, 5, "پردازنده نسل ۱۳", true, "پردازنده Intel i7", 20000000m },
                    { 43, 5, "مادربرد گیمینگ", true, "مادربرد ASUS", 15000000m },
                    { 44, 5, "حافظه رم باس بالا", true, "رم DDR5 16GB", 5000000m },
                    { 45, 5, "اس‌اس‌دی پرسرعت", true, "SSD 1TB NVMe", 7000000m },
                    { 46, 5, "پاور گرین ۷۵۰ وات", true, "پاور 750W", 3500000m },
                    { 47, 5, "کیس حرفه‌ای", true, "کیس گیمینگ", 4500000m },
                    { 48, 5, "خنک‌کننده پردازنده", true, "کولر پردازنده", 2200000m },
                    { 49, 5, "مانیتور 144Hz گیمینگ", true, "مانیتور 27 اینچ", 12000000m },
                    { 50, 5, "ماوس پد RGB", true, "ماوس پد گیمینگ", 400000m },
                    { 51, 6, "تی‌شرت نخی راحتی", true, "تی‌شرت مردانه", 300000m },
                    { 52, 6, "شلوار جین آبی", true, "شلوار جین", 800000m },
                    { 53, 6, "کفش اسپرت سفید", true, "کفش اسپرت", 1200000m },
                    { 54, 6, "کاپشن ضد آب", true, "کاپشن زمستانی", 2500000m },
                    { 55, 6, "پیراهن مردانه کلاسیک", true, "پیراهن رسمی", 900000m },
                    { 56, 6, "ساعت مچی اسپرت", true, "ساعت مچی", 3500000m },
                    { 57, 6, "عینک UV400", true, "عینک آفتابی", 700000m },
                    { 58, 6, "کفش چرمی مردانه", true, "کفش مجلسی", 2000000m },
                    { 59, 6, "روسری نخی طرح‌دار", true, "روسری زنانه", 500000m },
                    { 60, 6, "کمربند چرم طبیعی", true, "کمربند چرمی", 600000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "خانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "موبایل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "لپ تاپ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "کامپیوتر");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "توضیحات محصول یک", "محصول یک", 1000000m });
        }
    }
}
