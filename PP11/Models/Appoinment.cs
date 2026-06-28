using PP11.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PP11.Models
{
    internal class Appoinment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Discription { get; set; }

        public string StatusOfAppointment {  get; set; }

        public int RequestId { get; set; }

        public int BrigadeId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request? Request { get; set; }

        [ForeignKey(nameof(BrigadeId))]
        public Brigade? Brigade { get; set; }


        public Appoinment(string name, string? discription, string danger, string statusOfAppointment, int requestId, int brigadeId)
        {
            Name = name;
            Discription = discription;

            StatusOfAppointment = statusOfAppointment;
            RequestId = requestId;
            BrigadeId = brigadeId;
        }
        public Appoinment() { }
    }
}
