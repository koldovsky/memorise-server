using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDTO
{
    public class AnswerDTO: BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public virtual CardDTO Card { get; set; }
    }
}
