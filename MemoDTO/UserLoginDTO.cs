using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class UserLoginDTO
    {
        [StringLength(30,ErrorMessage ="maximum length 30 characters" )]
        public string Login { get; set; }
        
        [StringLength(100, ErrorMessage = "The minimum lenngth must be at " +
         "least 6 characters long.")]
        public string Password { get; set; }

        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
        ErrorMessage = "Wrong email")]
        public string Email { get; set; }
    }
}
