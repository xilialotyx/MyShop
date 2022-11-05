using _01_MyShopQuery.Contracts.ArticleCategory;
using _01_MyShopQuery.Contracts.ProductCategory;
using System.Collections.Generic;

namespace _01_MyShopQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
