using System;
using System.Collections.Generic;
using System.Text;

namespace PP11.Models
{
    internal class Abonent
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public DateTime Birthsday { get; set; }

        public int LichesevoiSchet { get; set; }

        public int PassportSer {  get; set; }

        public int PassportNum { get; set; }

        public string? DopInformation { get; set; }

        
        public Abonent(string fIO, DateTime birthsday, int lichesevoiSchet, int passportSer, int passportNum, string? dopInformation)
        {
            FIO = fIO;
            Birthsday = birthsday;
            LichesevoiSchet = lichesevoiSchet;
            PassportSer = passportSer;
            PassportNum = passportNum;
            DopInformation = dopInformation;
        }
        public Abonent() { }
    }
}
