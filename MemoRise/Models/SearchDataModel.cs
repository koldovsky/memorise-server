namespace MemoRise.Models
{
    public class SearchDataModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool Sort { get; set; }
        public string SearchString { get; set; }

        public string DeckLinking { get; set; }
    }
}