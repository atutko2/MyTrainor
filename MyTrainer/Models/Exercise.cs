using System;
using System.Collections.Generic;

namespace MyTrainer.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        public string Force { get; set; }
        public string Level { get; set; }
        public string Mechanic { get; set; }
        public string Equipment { get; set; }
        public IList<string> PrimaryMuscles { get; set; }
        public IList<string> SecondaryMuscles { get; set; }
        public IList<string> Instructions { get; set; }
        public string Category { get; set; }

        public Exercise()
        {
        }
    }
}

