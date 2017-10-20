using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBll.Interfaces
{
    public interface IDecoderBase64
    {
        CategoryDTO DecodeCategory(CategoryDTO category);

        CourseDTO DecodeCourse(CourseDTO course);

        CourseWithDecksDTO DecodeCourseWithDecks(CourseWithDecksDTO course);

        DeckDTO DecodeDeck(DeckDTO deck);
    }
}
