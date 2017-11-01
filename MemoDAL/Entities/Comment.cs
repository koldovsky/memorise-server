﻿namespace MemoDAL.Entities
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }

        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
        public virtual Card Card { get; set; }
    }
}