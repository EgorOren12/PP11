using PP11.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PP11.Models
{
    internal class Object
    {
        public int Id { get; set; }

        public string Adress { get; set; }

        public string Zones { get; set; }

        public string ObjectsType { get; set; }

        public string OborudovanieType { get; set; }

        public int YearExpluatation { get; set; }

        public string StatusOborudovaniya { get; set; }
        public int AbonentID { get; set; }

        [ForeignKey(nameof(AbonentID))]
        public Abonent? Abonent { get; set; }

        public Object(int id, string adress, string zones, string objectsType, string oborudovanieType, int yearExpluatation, string statusOborudovaniya, int abonentID)
        {
            Id = id;
            Adress = adress;
            Zones = zones;
            ObjectsType = objectsType;
            OborudovanieType = oborudovanieType;
            YearExpluatation = yearExpluatation;
            StatusOborudovaniya = statusOborudovaniya;
            AbonentID = abonentID;

        }
        public Object() { }
    }
}
