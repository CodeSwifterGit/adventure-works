using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseDocument : IBaseEntity
    {
        public int DocumentID { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Revision { get; set; }

        public int ChangeNumber { get; set; }

        public byte Status { get; set; }

        public string DocumentSummary { get; set; }

        public byte[] Document { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}