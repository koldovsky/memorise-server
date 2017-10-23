using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IConverterToDto
    {
        DeckDTO ConvertToDeckDto(Deck deck);

        List<DeckDTO> ConvertToDeckListDto(IEnumerable<Deck> decks);

        CourseDTO ConvertToCourseDto(Course course);

        List<CourseDTO> ConvertToCourseListDto(IEnumerable<Course> courses);

        CourseWithDecksDTO ConvertToCourseWithDecksDto(Course course);

        CategoryDTO ConvertToCategoryDto(Category category);

        CardTypeDTO ConvertToCardTypeDto(CardType cardtype);

        List<CardTypeDTO> ConvertToCardTypeListDto(IEnumerable<CardType> cardTypes);

        AnswerDTO ConvertToAnswerDto(Answer answer);

        List<AnswerDTO> ConvertToAnswerListDto(IEnumerable<Answer> answers);

        RoleDTO ConvertToRoleDto(Role role);

        UserDTO ConvertToUserDto(User user);

        List<UserDTO> ConvertToUserListDto(IEnumerable<User> users);

        CardDTO ConvertToCardDto(Card card);

        List<CardDTO> ConvertToCardListDto(IEnumerable<Card> cards);

        CommentDTO ConvertToCommentDto(Comment comment);

        List<CommentDTO> ConvertToCommentListDto(IEnumerable<Comment> comments);

        ReportDTO ConvertToReportDto(Report report);

        StatisticsDTO ConvertToStatisticsDto(Statistics statistics);

        List<StatisticsDTO> ConvertToStatisticsListDto(IEnumerable<Statistics> statistics);

        SubscribedCourseDTO ConvertToSubscribedCourseDto(SubscribedCourse subscribedCourse);

        SubscribedDeckDTO ConvertToSubscribedDeckDto(SubscribedDeck subscribedDeck);
    }
}