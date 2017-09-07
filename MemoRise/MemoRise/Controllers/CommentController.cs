using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class CommentController : ApiController
    {
        private CommentBll commentbll = new Comment();

        public Comment GetComment(int id)
        {
            return commentbll.GetComment(id);
        }

        public void PostComment(Comment item)
        {
            commentbll.AddComment(item);
        }

        public bool PutComment(Comment item)
        {
            return commentbll.UpdateComment(item);
        }

        public void DeleteComment(int id)
        {
            commentbll.RemoveComment(id);
        }
    }
}
