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

        Algorithm ConvertToAlgorithm(AlgorithmDTO algorithmDTO);

        List<Answer> ConvertToAnswerList(IEnumerable<AnswerDTO> answers);

        Role ConvertToRole(RoleDTO role);

        User ConvertToUser(UserDTO user);

        UserProfile ConvertToUserProfile(UserDTO user);

        List<User> ConvertToUserList(IEnumerable<UserDTO> users);

        Card ConvertToCard(CardDTO card);

        List<Card> ConvertToCardList(IEnumerable<CardDTO> cards);

        Comment ConvertToComment(CommentDTO comment);

        List<Comment> ConvertToCommentList(IEnumerable<CommentDTO> comments);

        Report ConvertToReport(ReportDTO report);

        Statistics ConvertToStatistics(StatisticsDTO statistics);

        CourseSubscription ConvertToCourseSubscription(CourseSubscriptionDTO courseSubscription);

        DeckSubscription ConvertToDeckSubscription(DeckSubscriptionDTO deckSubscription);
    }
}