using System;
namespace MyTrainer.Models
{
    public class Profile
    {
        public Profile()
        {
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExperienceLevel { get; set; } // Will be an enum with options
        public string Goals { get; set; } // May be an enum with options
        public int Height { get; set; } // Will calculate total inches based on input
        public int Weight { get; set; }
    }
}

