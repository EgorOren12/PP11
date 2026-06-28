using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PP11.Models
{
    internal class MembersOfBrigade
    {
        public int Id { get; set; }

        public string RoleInBrigade { get; set; }

        public int BrigadeId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        [ForeignKey(nameof(BrigadeId))]
        public Brigade? Brigade { get; set; }

        public MembersOfBrigade(string roleInBrigade, int employeeId, int brigadeId) 
        {
            RoleInBrigade = roleInBrigade;
            BrigadeId = brigadeId;
            EmployeeId = employeeId;
        }
        public MembersOfBrigade() { }
    }
}
