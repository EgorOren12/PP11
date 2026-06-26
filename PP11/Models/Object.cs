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

        public Zones Zones { get; set; }

        public ObjectsType ObjectsType { get; set; }

        public OborudovanieType OborudovanieType { get; set; }

        public int YearExpluatation { get; set; }

        public StatusOborudovaniya StatusOborudovaniya { get; set; }
        public int AbonentID { get; set; }

        [ForeignKey(nameof(AbonentID))]
        public Abonent? Abonent { get; set; }

        public Object(int id, string adress, Zones zones, ObjectsType objectsType, OborudovanieType oborudovanieType, int yearExpluatation, StatusOborudovaniya statusOborudovaniya, int abonentID)
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
