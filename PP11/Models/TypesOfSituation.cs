using PP11.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PP11.Models
{
    internal class TypesOfSituation
    {
        public int ID {  get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Danger {  get; set; }

        public TimeSpan ABSTime {  get; set; } 

        public TypesOfSituation(string name, string description, string danger, TimeSpan timeOnly)
        {
            Name = name;
            Description = description;
            Danger = danger;
            ABSTime = timeOnly;
        }
        public TypesOfSituation() { }
    }
}
