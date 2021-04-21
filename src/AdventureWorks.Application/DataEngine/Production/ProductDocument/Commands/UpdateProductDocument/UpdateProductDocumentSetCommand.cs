using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument
{
    public partial class UpdateProductDocumentSetCommand : IRequest<List<ProductDocumentLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductDocumentCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductDocument>, List<UpdateProductDocumentCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductDocumentCommand>, List<Entities.ProductDocument>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductDocument>, List<Entities.ProductDocument>>(MemberList.None);
        }
    }
}