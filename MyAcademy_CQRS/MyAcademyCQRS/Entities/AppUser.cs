using Microsoft.AspNetCore.Identity;

namespace MyAcademyCQRS.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; } 
    }
}
