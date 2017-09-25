using System.Collections.Generic;
using MemoDTO;
using MemoDAL.Entities;

namespace MemoBll
{
    public interface IConverterToDTO
    {
        DeckDTO ConvertToDeckDTO(Deck deck);
        List<DeckDTO> ConvertToDeckListDTO(IEnumerable<Deck> decks);
        CourseDTO ConvertToCourseDTO(Course course);
        List<CourseDTO> ConvertToCourseListDTO(IEnumerable<Course> courses);
        CourseWithDecksDTO ConvertToCourseWithDecksDTO(Course course);
        CategoryDTO ConvertToCategoryDTO(Category category);
        CardTypeDTO ConvertToCardTypeDTO(CardType cardtype);
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
        StatisticDTO ConvertToStatisticDTO(Statistics statistic);
        UserCourseDTO ConvertToUserCourseDTO(UserCourse userCourse);}
}
