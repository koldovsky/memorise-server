using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MemoDAL.Entities
{
    public class User : IdentityUser
    {
        
        
        public virtual UserProfile UserProfile { get; set; }
          
    }
}