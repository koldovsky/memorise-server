using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IConverterToDTO
    {
        AlgorithmDTO ConvertToAlgorithmDTO(Algorithm answer);

        List<AlgorithmDTO> ConvertToAlgorithmListDTO(IEnumerable<Algorithm> algorithms);

        DeckDTO ConvertToDeckDTO(Deck deck);

        List<DeckDTO> ConvertToDeckListDTO(IEnumerable<Deck> decks);

        CourseDTO ConvertToCourseDTO(Course course);

        List<CourseDTO> ConvertToCourseListDTO(IEnumerable<Course> courses);

        CourseWithDecksDTO ConvertToCourseWithDecksDTO(Course course);

        CategoryDTO ConvertToCategoryDTO(Category category);

        CardTypeDTO ConvertToCardTypeDTO(CardType cardtype);

        List<CardTypeDTO> ConvertToCardTypeListDTO(IEnumerable<CardType> cardTypes);

        AnswerDTO ConvertToAnswerDTO(Answer answer);

        List<AnswerDTO> ConvertToAnswerListDTO(IEnumerable<Answer> answers);

        RoleDTO ConvertToRoleDTO(Role role);

        UserDTO ConvertToUserDTO(User user);

        List<UserDTO> ConvertToUserListDTO(IEnumerable<User> users);

        CardDTO ConvertToCardDTO(Card card);

        List<CardDTO> ConvertToCardListDTO(IEnumerable<Card> cards);

        CommentDTO ConvertToCommentDTO(Comment comment);

        List<CommentDTO> ConvertToCommentListDTO(IEnumerable<Comment> comments);

        ReportDTO ConvertToReportDTO(Report report);

        StatisticsDTO ConvertToStatisticsDTO(Statistics statistics);

        List<StatisticsDTO> ConvertToStatisticsListDTO(IEnumerable<Statistics> statistics);

        CourseSubscriptionDTO ConvertToCourseSubscriptionDTO(CourseSubscription subscription);

        DeckSubscriptionDTO ConvertToDeckSubscriptionDTO(DeckSubscription subscription);
    }
}