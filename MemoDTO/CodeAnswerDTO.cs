using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDTO
{
    public class CodeAnswerDTO
    {
        public int CardId { get; set; }

        public string CodeAnswerText { get; set; }

        public bool IsRight { get; set; }
    }
}
