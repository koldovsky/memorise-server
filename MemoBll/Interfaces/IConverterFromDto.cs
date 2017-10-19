using System.Collections.Generic;
using MemoDAL.Entities;
using MemoDTO;

namespace MemoBll.Interfaces
{
    public interface IConverterFromDTO
    {
        Deck ConvertToDeck(DeckDTO deck);
        List<Deck> ConvertToDeckList(IEnumerable<DeckDTO> decks);
        Course ConvertToCourse(CourseDTO course);
        List<Course> ConvertToCourseList(IEnumerable<CourseDTO> courses);
        Category ConvertToCategory(CategoryDTO category);
        CardType ConvertToCardType(CardTypeDTO cardtype);
        Answer ConvertToAnswer(AnswerDTO answer);
        List<Answer> ConvertToAnswerList(IEnumerable<AnswerDTO> answers);
        Role ConvertToRole(RoleDTO role);
        User ConvertToUser(UserDTO user);
        List<User> ConvertToUserList(IEnumerable<UserDTO> users);
        Card ConvertToCard(CardDTO card);
        List<Card> ConvertToCardList(IEnumerable<CardDTO> cards);
        Comment ConvertToComment(CommentDTO comment);
        List<Comment> ConvertToCommentList(IEnumerable<CommentDTO> comments);
        Report ConvertToReport(ReportDTO report);
        Statistics ConvertToStatistics(StatisticsDTO statistics);
        SubscribedCourse ConvertToSubscribedCourse(SubscribedCourseDTO subscribedCourse);
        SubscribedDeck ConvertToSubscribedDeck(SubscribedDeckDTO subscribedDeck);
    }
}

