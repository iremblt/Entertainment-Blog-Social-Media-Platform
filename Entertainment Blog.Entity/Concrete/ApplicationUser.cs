using System;
using System.Collections.Generic;
using Entertainment_Blog.Entity.Enums;
using Microsoft.AspNetCore.Identity;

namespace Entertainment_Blog.Entity.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ConfirmPassword { get; set; }
        public GenderTypes Gender { get; set; }
        public CountryTypes Country { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
        public string About { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}