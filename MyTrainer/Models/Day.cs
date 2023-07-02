using System;
namespace MyTrainer.Models
{
    public class Day
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public Day()
        {
        }
        public Day(string name)
        {
            Name = name;
        }
        public Day(string name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }
    }
}

