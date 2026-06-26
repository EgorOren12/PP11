using PP11.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text;

namespace PP11.Models
{
    internal class Brigade
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Zones Zones { get; set; }

        public string Transport { get; set; }

        public Filials Filials { get; set; }

        public int EmployeeID {  get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public Employee? Employee { get; set; }

        public MembersOfBrigade? MembersOfBrigade { get; set; }

        public Brigade(int id, string name, Zones zones, string transport, Filials filials, int employeeId) 
        {
            Id = id;
            Name = name;
            Zones = zones;
            Transport = transport;
            Filials = filials;
            EmployeeID = employeeId;
        }
        public Brigade() { }
    }
}
