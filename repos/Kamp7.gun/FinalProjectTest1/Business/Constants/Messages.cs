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
        public static string ProductDetail = "Product detay listelendi!";
        public static string ProductCountOfCategoryError= "Ürün kategorisi sayisi 10 sinirini geciyor";
        internal static string ProductNameAlreadyExist = "Eklemeye çalıştığınız ürün zaten mevcuttur";
        internal static string CategoriesListed= "Kategoriler Listelendi";
        internal static string CategoryDetail= "Kategori detay listelendi!";
        internal static string CategoryLimitExceded="Kategori limiti aşıldı";
    }
}
