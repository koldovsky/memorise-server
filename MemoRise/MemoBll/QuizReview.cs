using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class QuizReview
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public List<Comment> GetAllCommentsInCard(int cardId)
        {
            return unitOfWork.Cards.Get(cardId).Comments.ToList();
        }

        public List<Comment> GetAllCommets()
        {
            return unitOfWork.Comments.GetAll().ToList();
        }

        public Comment GetComment(int commentId)
        {
            return unitOfWork.Comments.Get(commentId);
        }

        public void CreateComment(Comment comment)
        {
            unitOfWork.Comments.Create(comment);
        }

        public void UpdateComment(Comment comment)
        {
            unitOfWork.Comments.Update(comment);
        }

        public void RemoveComment(Comment comment)
        {
            unitOfWork.Comments.Delete(comment);
        }
    }
}
