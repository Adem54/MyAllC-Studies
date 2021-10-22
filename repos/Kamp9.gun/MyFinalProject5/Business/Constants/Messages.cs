using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi!";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir!";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProcessFailed = "İşlem başarısız oldu";
        public static string ProductDeleted = "Ürün silindi!";
        public static string ProductUpdated = "Ürün güncellendi!";
        public static string ProductCountOfCategoryError = "Bir kategori de en fazla 10 ürün olabilir ";
        public static string ProductNameAlreadyExist = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldıgı için yeni ürün eklenemiyor";
        internal static string CategoriesListed="Kategoriler listelendi";
    }
}
