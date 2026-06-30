using PP11.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PP11.Models
{
    internal class Employee
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Post { get; set; }

        public string Cvalification { get; set; }

        public string TimeOfWork { get; set; }

        public Brigade? Brigade { get; set; }

        MembersOfBrigade? membersOfBrigade {  get; set; }

        public Employee(string fIO, string post, string cvalification, string timeOfWork)
        {
            FIO = fIO;
            Post = post;
            Cvalification = cvalification;
            TimeOfWork = timeOfWork;
        }
        public Employee() { }
    }
}
