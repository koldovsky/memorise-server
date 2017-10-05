using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL.Entities;
using MemoDTO;


namespace MemoBll.Interfaces
{
    interface IConverterFromDto
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
        Statistics ConvertToStatistic(StatisticDTO statistic);
        UserCourse ConvertToUserCourse(UserCourseDTO userCourse);
    }
}

