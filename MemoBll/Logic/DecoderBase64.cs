using MemoBll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDTO;

namespace MemoBll.Logic
{
    public class DecoderBase64 : IDecoderBase64
    {
        public CategoryDTO DecodeCategory(CategoryDTO category)
        {
            category.Name = Encoding.UTF8.GetString(
                             Convert.FromBase64String(category.Name));
            category.Linking = Encoding.UTF8.GetString(
                              Convert.FromBase64String(category.Linking));
            return category;
        }

        public CourseDTO DecodeCourse(CourseDTO course)
        {
            course.Name = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Name));
            course.Linking = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Linking));
            course.Description = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Description));
            return course;
        }

        public CourseWithDecksDTO DecodeCourseWithDecks(CourseWithDecksDTO course)
        {
            course.Name = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Name));
            course.Linking = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Linking));
            course.Description = Encoding.UTF8.GetString(
                              Convert.FromBase64String(course.Description));
            return course;
        }

        public DeckDTO DecodeDeck(DeckDTO deck)
        {
            deck.Name = Encoding.UTF8.GetString(
                              Convert.FromBase64String(deck.Name));
            deck.Linking = Encoding.UTF8.GetString(
                              Convert.FromBase64String(deck.Linking));
            deck.Description = Encoding.UTF8.GetString(
                              Convert.FromBase64String(deck.Description));
            return deck;
        }
    }
}
