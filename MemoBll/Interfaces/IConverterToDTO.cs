using MemoDAL.Entities;
using MemoDTO;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IConverterToDTO
    {
		AnswerDTO ConvertToAnswerDTO(Answer answer);
		CardDTO ConvertToCardDTO(Card card);
		CardTypeDTO ConvertToCardTypeDTO(CardType cardtype);
		CategoryDTO ConvertToCategoryDTO(Category category);
		CommentDTO ConvertToCommentDTO(Comment comment);
		CourseDTO ConvertToCourseDTO(Course course);
		CourseWithDecksDTO ConvertToCourseWithDecksDTO(Course course);
		DeckDTO ConvertToDeckDTO(Deck deck);
		ReportDTO ConvertToReportDTO(Report report);
		RoleDTO ConvertToRoleDTO(Role role);
		StatisticDTO ConvertToStatisticDTO(Statistics statistic);
		UserDTO ConvertToUserDTO(User user);
		UserCourseDTO ConvertToUserCourseDTO(UserCourse userCourse);

        List<AnswerDTO> ConvertToAnswerListDTO(IEnumerable<Answer> answers);
        List<CommentDTO> ConvertToCommentListDTO(IEnumerable<Comment> comments);
		List<DeckDTO> ConvertToDeckListDTO(IEnumerable<Deck> decks);
		List<UserDTO> ConvertToUserListDTO(IEnumerable<User> users);
    }
}
