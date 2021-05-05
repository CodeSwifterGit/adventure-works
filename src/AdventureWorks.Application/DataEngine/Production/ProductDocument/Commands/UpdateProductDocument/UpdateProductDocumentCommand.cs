using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument
{
    public partial class UpdateProductDocumentCommand : IRequest<ProductDocumentLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public int DocumentID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductDocumentRequestTarget RequestTarget { get; set; }

        public UpdateProductDocumentCommand()
        {
        }

        public UpdateProductDocumentCommand(int productID, int documentID, BaseProductDocument model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductDocumentRequestTarget(productID, documentID);
        }

        public UpdateProductDocumentCommand(int productID, int documentID)
        {
            ProductID = productID;
            DocumentID = documentID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductDocument, UpdateProductDocumentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductDocumentCommand, Entities.ProductDocument>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductDocument, Entities.ProductDocument>(MemberList.None);
        }

        public partial class UpdateProductDocumentRequestTarget
        {
            public int ProductID { get; set; }
            public int DocumentID { get; set; }

            public UpdateProductDocumentRequestTarget()
            {
            }

            public UpdateProductDocumentRequestTarget(int productID, int documentID)
            {
                ProductID = productID;
                DocumentID = documentID;
            }
        }
    }
}