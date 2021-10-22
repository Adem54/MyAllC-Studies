using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductDetailListed = "Üründetayı listelendi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün silindi";
        internal static string ProductCountOfCategoryError= "Bir kategori de en fazla 10 ürün olabilir";
        internal static string ProductNameAlreadyExist= "Bu isimde zaten başka bir ürün var";
        internal static string CategoriesListed="Kategoriler listelendi";
        internal static string CategoryDetailListed="Kategori detayı listelendi";
        internal static string CategoryLimitedExceded="Kategori limiti aşıldı";
    }
}
