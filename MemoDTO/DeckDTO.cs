using System.Collections.Generic;

namespace MemoDTO
{
    public class DeckDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CardsNumber { get; set; }
		public string Photo { get; set; }
        public string Linking { get; set; }
        public string CategoryName { get; set; }
        public List<string> CardIds { get; set; }
        public List<string> CourseNames { get; set; }
    }
}