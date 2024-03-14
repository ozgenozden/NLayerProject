using System;
namespace Business.Constants
{
	public static class Messages
	{
        internal static readonly string ProductOfCategoryError = "Eklemek istediğiniz ürün sayısı 10 u aştı";
        internal static readonly string ProductNameAlreadyExists="Ürün ismi halihazırda var";
        public static string ProductAdded = "Ürün Eklendi."; 
        public static string ProductHasBeenListed = "Ürünler Listelendi.";
        public static string ProductNameInvalid = "Ürün ismi Geçersiz.";

        public static string? AuthorizationDenied = "Yetkisiz giriş";
    }
}

