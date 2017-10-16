﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDTO
{
    public class CourseWithDecksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Linking { get; set; }
        public string Description { get; set; }
		public string Photo { get; set; }
        public int Price { get; set; }
		public IEnumerable<DeckDTO> Decks { get; set; }
        public CategoryDTO Category { get; set; }
        public string CategoryName { get; set; }
        public string[] DeckNames { get; set; }
    }
}
