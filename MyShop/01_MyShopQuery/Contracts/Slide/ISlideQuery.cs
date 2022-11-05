using System.Collections.Generic;

namespace _01_MyShopQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
