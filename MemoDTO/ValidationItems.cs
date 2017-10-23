using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDTO
{
    public static class ValidationItems
    {
        public const int MAX_LENGTH_INPUT = 20;
        public const int MAX_LENGTH_TEXTAREA = 250;
        public const string INPUT_REGEX = @"[ a-zA-Z0-9-_.,:#+/&()]+$";
        public const string ONLY_ALPHANUMERIC = @"[a-zA-Z0-9]+$";
        public const string ONLY_NUMBERS = "[0-9]{1,3}";
    }
}
