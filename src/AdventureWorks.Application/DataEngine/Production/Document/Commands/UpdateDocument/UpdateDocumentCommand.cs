using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument
{
    public partial class UpdateDocumentCommand : BaseDocument, IRequest<DocumentLookupModel>, IHaveCustomMapping
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

        public UpdateDocumentRequestTarget RequestTarget { get; set; }

        public UpdateDocumentCommand()
        {
        }

        public UpdateDocumentCommand(int documentID, BaseDocument model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateDocumentRequestTarget(documentID);
        }

        public UpdateDocumentCommand(int documentID)
        {
            DocumentID = documentID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDocument, UpdateDocumentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateDocumentCommand, Entities.Document>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Document, Entities.Document>(MemberList.None);
        }

        public partial class UpdateDocumentRequestTarget
        {
            public int DocumentID { get; set; }

            public UpdateDocumentRequestTarget()
            {
            }

            public UpdateDocumentRequestTarget(int documentID)
            {
                DocumentID = documentID;
            }
        }
    }
}