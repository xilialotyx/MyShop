using _0_Framework.Domain;

namespace SiteManagement.Domain.optionCategoryAgg
{
    public class optionCategory : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public int? Order { get; set; }
        public string ValueType { get; set; }

        public int? OptionCategoryId { get; set; }
    }
}