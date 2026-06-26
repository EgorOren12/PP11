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

        public string LichesevoiSchet { get; set; }

        public int PassportSer {  get; set; }

        public int PassportNum { get; set; }

        public string? DopInformation { get; set; }

        
        public Abonent(int id, string fIO, DateTime birthsday, string lichesevoiSchet, int passportSer, int passportNum, string? dopInformation)
        {
            Id = id;
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
