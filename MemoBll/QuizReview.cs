using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll
{
    public class QuizReview
    {
        private IUnitOfWork unitOfWork;

        public QuizReview()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public QuizReview(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

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
            return unitOfWork.Comments.Get(commentId) ?? throw new ArgumentNullException();
        }

        public void CreateComment(Comment comment)
        {
            unitOfWork.Comments.Create(comment);
        }

        public void UpdateComment(Comment comment)
        {
            unitOfWork.Comments.Update(comment);
        }

        public void RemoveComment(int commentId)
        {
            unitOfWork.Comments.Delete(commentId);
        }
    }
}
