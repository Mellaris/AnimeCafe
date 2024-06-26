using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCafe
{
    public static class AllLists
    {
        public static List<RegistrClassAccount> accounts = new List<RegistrClassAccount>();
        public static int? idUser;

        public static List<ProductClassAdd> products = new List<ProductClassAdd>();
        public static List<string> typeProd = new List<string> { "Фигурка", "Брелок", "Чашка", "Бокс", "Одежда" };

        public static int idAdmin = 0;

        public static List<PromokodsAddClass> promos = new List<PromokodsAddClass>();

        public static string textToCopy;

        public static List<ArticleInfoAdd> articles = new List<ArticleInfoAdd>();
        public static List<ArticleInfoAdd> articleBig = new List<ArticleInfoAdd>();

        public static List<ProductClassAdd> topProd = new List<ProductClassAdd>();

        public static string textPromoHelp;

        public static bool clickButtonPromo = true;
        public static bool clickButtonBonus = true;

        public static List<ProductClassAdd> productsForEdit = new List<ProductClassAdd>();
        public static List<ArticleInfoAdd> articleForEdit = new List<ArticleInfoAdd>();
    }
}
