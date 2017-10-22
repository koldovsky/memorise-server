using MemoBll.Interfaces;
using System;
using System.Text;
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

        public UserDTO DecodeUser(UserDTO user)
        {
            user.Login = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.Login));
            user.FirstName = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.FirstName));
            user.LastName = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.LastName));
            user.Gender = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.Gender));
            user.Country = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.Country));
            user.City = Encoding.UTF8.GetString(
                Convert.FromBase64String(user.City));
            return user;
        }
    }
}
