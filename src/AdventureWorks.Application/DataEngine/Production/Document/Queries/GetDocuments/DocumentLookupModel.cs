using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;


namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments
{
    public partial class DocumentLookupModel : IHaveCustomMapping
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

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Production.Document, DocumentLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<DocumentLookupModel, BaseDocument>().IgnoreMissingDestinationMembers();
        }
    }
}
