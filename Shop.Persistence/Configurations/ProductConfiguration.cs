using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            #region Seed Data

            builder.HasData(
                // دسته ۱: لوازم ورزشی
                new Product { Id = 1, CategoryId = 1, Name = "توپ فوتبال", Description = "توپ حرفه‌ای فوتبال سایز ۵", IsActive = true, Price = 350000 },
                new Product { Id = 2, CategoryId = 1, Name = "کفش ورزشی نایک", Description = "کفش مخصوص دویدن", IsActive = true, Price = 2200000 },
                new Product { Id = 3, CategoryId = 1, Name = "دمبل ۱۰ کیلویی", Description = "ست دمبل مناسب بدنسازی", IsActive = true, Price = 800000 },
                new Product { Id = 4, CategoryId = 1, Name = "طناب ورزشی", Description = "طناب مناسب برای تمرین هوازی", IsActive = true, Price = 150000 },
                new Product { Id = 5, CategoryId = 1, Name = "تشک یوگا", Description = "تشک مخصوص حرکات یوگا و پیلاتس", IsActive = true, Price = 300000 },
                new Product { Id = 6, CategoryId = 1, Name = "دستکش بدنسازی", Description = "دستکش ورزشی ضدلغزش", IsActive = true, Price = 180000 },
                new Product { Id = 7, CategoryId = 1, Name = "دوچرخه ثابت", Description = "دوچرخه ثابت خانگی", IsActive = true, Price = 5500000 },
                new Product { Id = 8, CategoryId = 1, Name = "کش مقاومتی", Description = "ست کش تمرینی چندکاره", IsActive = true, Price = 250000 },
                new Product { Id = 9, CategoryId = 1, Name = "کیسه بوکس", Description = "کیسه بوکس ایستاده", IsActive = true, Price = 1800000 },
                new Product { Id = 10, CategoryId = 1, Name = "لباس ورزشی", Description = "ست تیشرت و شلوار ورزشی", IsActive = true, Price = 400000 },

                // دسته ۲: لوازم خانگی
                new Product { Id = 11, CategoryId = 2, Name = "یخچال فریزر", Description = "یخچال فریزر دو قلو سامسونگ", IsActive = true, Price = 35000000 },
                new Product { Id = 12, CategoryId = 2, Name = "ماشین لباسشویی", Description = "لباسشویی اتوماتیک ۸ کیلویی", IsActive = true, Price = 18000000 },
                new Product { Id = 13, CategoryId = 2, Name = "مایکروویو", Description = "مایکروویو ۴۰ لیتری", IsActive = true, Price = 7500000 },
                new Product { Id = 14, CategoryId = 2, Name = "جاروبرقی", Description = "جاروبرقی ۲۲۰۰ وات", IsActive = true, Price = 4500000 },
                new Product { Id = 15, CategoryId = 2, Name = "پنکه ایستاده", Description = "پنکه پرقدرت ۳ سرعته", IsActive = true, Price = 1200000 },
                new Product { Id = 16, CategoryId = 2, Name = "غذا ساز", Description = "غذا ساز چندکاره", IsActive = true, Price = 3800000 },
                new Product { Id = 17, CategoryId = 2, Name = "اتو بخار", Description = "اتو بخار حرفه‌ای", IsActive = true, Price = 900000 },
                new Product { Id = 18, CategoryId = 2, Name = "کتری برقی", Description = "کتری برقی استیل ۲ لیتری", IsActive = true, Price = 600000 },
                new Product { Id = 19, CategoryId = 2, Name = "قهوه‌ساز", Description = "قهوه‌ساز فیلیپس", IsActive = true, Price = 4200000 },
                new Product { Id = 20, CategoryId = 2, Name = "ماشین ظرفشویی", Description = "ظرفشویی ۱۴ نفره بوش", IsActive = true, Price = 25000000 },

                // دسته ۳: موبایل و تبلت
                new Product { Id = 21, CategoryId = 3, Name = "آیفون 14", Description = "گوشی اپل آیفون 14 پرو مکس", IsActive = true, Price = 65000000 },
                new Product { Id = 22, CategoryId = 3, Name = "سامسونگ S23", Description = "گوشی سامسونگ گلکسی S23", IsActive = true, Price = 48000000 },
                new Product { Id = 23, CategoryId = 3, Name = "شیائومی 13", Description = "گوشی شیائومی سری ۱۳", IsActive = true, Price = 25000000 },
                new Product { Id = 24, CategoryId = 3, Name = "تبلت آیپد پرو", Description = "تبلت اپل آیپد پرو ۱۲ اینچ", IsActive = true, Price = 58000000 },
                new Product { Id = 25, CategoryId = 3, Name = "تبلت سامسونگ Tab S9", Description = "تبلت اندرویدی سامسونگ", IsActive = true, Price = 30000000 },
                new Product { Id = 26, CategoryId = 3, Name = "شارژر سریع ۶۵ وات", Description = "شارژر اصل USB-C", IsActive = true, Price = 900000 },
                new Product { Id = 27, CategoryId = 3, Name = "ایرفون بلوتوث", Description = "ایرفون بی‌سیم", IsActive = true, Price = 1500000 },
                new Product { Id = 28, CategoryId = 3, Name = "کاور گوشی", Description = "کاور ضد ضربه سیلیکونی", IsActive = true, Price = 250000 },
                new Product { Id = 29, CategoryId = 3, Name = "محافظ صفحه", Description = "گلس ضدخش", IsActive = true, Price = 200000 },
                new Product { Id = 30, CategoryId = 3, Name = "پاوربانک ۲۰۰۰۰", Description = "پاوربانک شیائومی", IsActive = true, Price = 1600000 },

                // دسته ۴: لپ‌تاپ و لوازم جانبی
                new Product { Id = 31, CategoryId = 4, Name = "لپ‌تاپ ایسوس", Description = "لپ‌تاپ گیمینگ ایسوس", IsActive = true, Price = 42000000 },
                new Product { Id = 32, CategoryId = 4, Name = "لپ‌تاپ دل", Description = "لپ‌تاپ اداری دل", IsActive = true, Price = 28000000 },
                new Product { Id = 33, CategoryId = 4, Name = "لپ‌تاپ اپل مک‌بوک", Description = "مک‌بوک پرو ۱۴ اینچ", IsActive = true, Price = 70000000 },
                new Product { Id = 34, CategoryId = 4, Name = "موس گیمینگ", Description = "موس RGB گیمینگ", IsActive = true, Price = 1200000 },
                new Product { Id = 35, CategoryId = 4, Name = "کیبورد مکانیکال", Description = "کیبورد مکانیکال RGB", IsActive = true, Price = 1800000 },
                new Product { Id = 36, CategoryId = 4, Name = "کوله لپ‌تاپ", Description = "کوله ضد ضربه لپ‌تاپ", IsActive = true, Price = 900000 },
                new Product { Id = 37, CategoryId = 4, Name = "پایه خنک‌کننده", Description = "کول‌پد لپ‌تاپ", IsActive = true, Price = 800000 },
                new Product { Id = 38, CategoryId = 4, Name = "وب‌کم", Description = "وب‌کم HD مناسب تماس تصویری", IsActive = true, Price = 1500000 },
                new Product { Id = 39, CategoryId = 4, Name = "هدست گیمینگ", Description = "هدست با میکروفون", IsActive = true, Price = 2200000 },
                new Product { Id = 40, CategoryId = 4, Name = "هارد اکسترنال", Description = "هارد اکسترنال ۱ ترابایت", IsActive = true, Price = 2500000 },

                // دسته ۵: کامپیوتر و قطعات
                new Product { Id = 41, CategoryId = 5, Name = "کارت گرافیک RTX 4070", Description = "کارت گرافیک انویدیا", IsActive = true, Price = 60000000 },
                new Product { Id = 42, CategoryId = 5, Name = "پردازنده Intel i7", Description = "پردازنده نسل ۱۳", IsActive = true, Price = 20000000 },
                new Product { Id = 43, CategoryId = 5, Name = "مادربرد ASUS", Description = "مادربرد گیمینگ", IsActive = true, Price = 15000000 },
                new Product { Id = 44, CategoryId = 5, Name = "رم DDR5 16GB", Description = "حافظه رم باس بالا", IsActive = true, Price = 5000000 },
                new Product { Id = 45, CategoryId = 5, Name = "SSD 1TB NVMe", Description = "اس‌اس‌دی پرسرعت", IsActive = true, Price = 7000000 },
                new Product { Id = 46, CategoryId = 5, Name = "پاور 750W", Description = "پاور گرین ۷۵۰ وات", IsActive = true, Price = 3500000 },
                new Product { Id = 47, CategoryId = 5, Name = "کیس گیمینگ", Description = "کیس حرفه‌ای", IsActive = true, Price = 4500000 },
                new Product { Id = 48, CategoryId = 5, Name = "کولر پردازنده", Description = "خنک‌کننده پردازنده", IsActive = true, Price = 2200000 },
                new Product { Id = 49, CategoryId = 5, Name = "مانیتور 27 اینچ", Description = "مانیتور 144Hz گیمینگ", IsActive = true, Price = 12000000 },
                new Product { Id = 50, CategoryId = 5, Name = "ماوس پد گیمینگ", Description = "ماوس پد RGB", IsActive = true, Price = 400000 },

                // دسته ۶: پوشاک و مد
                new Product { Id = 51, CategoryId = 6, Name = "تی‌شرت مردانه", Description = "تی‌شرت نخی راحتی", IsActive = true, Price = 300000 },
                new Product { Id = 52, CategoryId = 6, Name = "شلوار جین", Description = "شلوار جین آبی", IsActive = true, Price = 800000 },
                new Product { Id = 53, CategoryId = 6, Name = "کفش اسپرت", Description = "کفش اسپرت سفید", IsActive = true, Price = 1200000 },
                new Product { Id = 54, CategoryId = 6, Name = "کاپشن زمستانی", Description = "کاپشن ضد آب", IsActive = true, Price = 2500000 },
                new Product { Id = 55, CategoryId = 6, Name = "پیراهن رسمی", Description = "پیراهن مردانه کلاسیک", IsActive = true, Price = 900000 },
                new Product { Id = 56, CategoryId = 6, Name = "ساعت مچی", Description = "ساعت مچی اسپرت", IsActive = true, Price = 3500000 },
                new Product { Id = 57, CategoryId = 6, Name = "عینک آفتابی", Description = "عینک UV400", IsActive = true, Price = 700000 },
                new Product { Id = 58, CategoryId = 6, Name = "کفش مجلسی", Description = "کفش چرمی مردانه", IsActive = true, Price = 2000000 },
                new Product { Id = 59, CategoryId = 6, Name = "روسری زنانه", Description = "روسری نخی طرح‌دار", IsActive = true, Price = 500000 },
                new Product { Id = 60, CategoryId = 6, Name = "کمربند چرمی", Description = "کمربند چرم طبیعی", IsActive = true, Price = 600000 }
            );

            #endregion

        }
    }
}
