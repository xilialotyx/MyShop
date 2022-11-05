using System.Collections.Generic;

namespace _01_MyShopQuery.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetArticleCategory(string slug);
        List<ArticleCategoryQueryModel> GetArticleCategories();
    }
}
