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

        public string Danger { get; set; }

        public string ABSTime {  get; set; }

        public int RequestId { get; set; }

        public int BrigadeId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request? Request { get; set; }

        [ForeignKey(nameof(BrigadeId))]
        public Brigade? Brigade { get; set; }


        public Appoinment(int id, string name, string? discription, string danger, string aBSTime, int requestId, int brigadeId)
        {
            Id = id;
            Name = name;
            Discription = discription;
            Danger = danger;
            ABSTime = aBSTime;
            RequestId = requestId;
            BrigadeId = brigadeId;
        }
        public Appoinment() { }
    }
}
