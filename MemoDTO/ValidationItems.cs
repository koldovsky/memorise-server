namespace MemoDTO
{
    public static class ValidationItems
    {
        public const int MAX_LENGTH_INPUT = 20;
        public const int MAX_LENGTH_TEXTAREA = 250;
        public const string INPUT_REGEX = @"[a-zA-Z0-9-_.:#+/&()]+$";
        public const string ONLY_ALPHANUMERIC = @"[a-zA-Z0-9]+$";
        public const string ONLY_NUMBERS = "[0-9]{1,3}";
        public const string EMAIL_PATTERN = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
    }
}
