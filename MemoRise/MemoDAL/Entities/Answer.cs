﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDAL.Entities
{
    public class Answer: BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Card Card { get; set; }
    }
}