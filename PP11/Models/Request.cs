using PP11.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PP11.Models
{
    internal class Request
    {
        public int Id { get; set; }

        public DateTime DateOfEnter { get; set; }

        public string DescriptionOfProblem { get; set; }

        public string SourceOfReguest { get; set; }

        public string Status { get; set; }

        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd  { get; set; }

        public string? DescriptionOfWork { get; set; }

        public string? UsingMaterials { get; set; }

        public DateTime? DateOfClosing { get; set; }

        public string? ResultOfAppoinment { get; set; }

        public string? CommentOfClose { get; set; }

        public bool? InformingOfAbonent { get; set; }


        public int AbonentId { get; set; }

        public int ObjectId { get; set; }

        public int TypeId   { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public Abonent? Abonent { get; set; }

        [ForeignKey(nameof(ObjectId))]
        public Object? Object { get; set; }

        [ForeignKey(nameof(TypeId))]
        public TypesOfSituation? TypesOfSituation { get; set; }


        public Request(DateTime dateOfEnter, string descriptionOfProblem, string sourceOfReguest, string status, DateTime? dateOfStart, DateTime? dateOfEnd, string? descriptionOfWork, string? usingMaterials, DateTime? dateOfClosing, string? resultOfAppoinment, string? commentOfClose, bool? informingOfAbonent, int abonentId, int objectId, int typeId)
        {
            DateOfEnter = dateOfEnter;
            DescriptionOfProblem = descriptionOfProblem;
            SourceOfReguest = sourceOfReguest;
            Status = status;
            DateOfStart = dateOfStart;
            DateOfEnd = dateOfEnd;
            DescriptionOfWork = descriptionOfWork;
            UsingMaterials = usingMaterials;
            DateOfClosing = dateOfClosing;
            ResultOfAppoinment = resultOfAppoinment;
            CommentOfClose = commentOfClose;
            InformingOfAbonent = informingOfAbonent;
            AbonentId = abonentId;
            ObjectId = objectId;
            TypeId = typeId;

        }
        public Request() { }
    }
}
