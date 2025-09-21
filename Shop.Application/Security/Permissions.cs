// Application/Common/Security/Permissions.cs
namespace Application.Common.Security;

public static class Permissions
{
    public static class Users
    {
        public const int Id = 1;
        public const string Name = "مدیریت کاربران";

        public static class Actions
        {
            public const int CreateId = 2;
            public const string CreateName = "افزودن کاربر";

            public const int UpdateId = 3;
            public const string UpdateName = "ویرایش کاربر";

            public const int DeleteId = 4;
            public const string DeleteName = "حذف کاربر";

            public const int ViewId = 5;
            public const string ViewName = "مشاهده کاربران";
        }
    }

    public static class Categories
    {
        public const int Id = 6;
        public const string Name = "مدیریت دسته‌بندی‌ها";

        public static class Actions
        {
            public const int CreateId = 7;
            public const string CreateName = "افزودن دسته‌بندی";

            public const int UpdateId = 8;
            public const string UpdateName = "ویرایش دسته‌بندی";

            public const int DeleteId = 9;
            public const string DeleteName = "حذف دسته‌بندی";

            public const int ViewId = 10;
            public const string ViewName = "مشاهده دسته‌بندی‌ها";
        }
    }

    public static class Products
    {
        public const int Id = 11;
        public const string Name = "مدیریت محصولات";

        public static class Actions
        {
            public const int CreateId = 12;
            public const string CreateName = "افزودن محصول";

            public const int UpdateId = 13;
            public const string UpdateName = "ویرایش محصول";

            public const int DeleteId = 14;
            public const string DeleteName = "حذف محصول";

            public const int ViewId = 15;
            public const string ViewName = "مشاهده محصولات";
        }
    }
}

public static class PermissionDictionary
{
    public static readonly Dictionary<string, int> NameToId = new()
    {
        // Users
        { Permissions.Users.Name, Permissions.Users.Id },
        { Permissions.Users.Actions.CreateName, Permissions.Users.Actions.CreateId },
        { Permissions.Users.Actions.UpdateName, Permissions.Users.Actions.UpdateId },
        { Permissions.Users.Actions.DeleteName, Permissions.Users.Actions.DeleteId },
        { Permissions.Users.Actions.ViewName, Permissions.Users.Actions.ViewId },

        // Categories
        { Permissions.Categories.Name, Permissions.Categories.Id },
        { Permissions.Categories.Actions.CreateName, Permissions.Categories.Actions.CreateId },
        { Permissions.Categories.Actions.UpdateName, Permissions.Categories.Actions.UpdateId },
        { Permissions.Categories.Actions.DeleteName, Permissions.Categories.Actions.DeleteId },
        { Permissions.Categories.Actions.ViewName, Permissions.Categories.Actions.ViewId },

        // Products
        { Permissions.Products.Name, Permissions.Products.Id },
        { Permissions.Products.Actions.CreateName, Permissions.Products.Actions.CreateId },
        { Permissions.Products.Actions.UpdateName, Permissions.Products.Actions.UpdateId },
        { Permissions.Products.Actions.DeleteName, Permissions.Products.Actions.DeleteId },
        { Permissions.Products.Actions.ViewName, Permissions.Products.Actions.ViewId },
    };
}
