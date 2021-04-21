using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument
{
    public partial class UpdateDocumentSetCommand : IRequest<List<DocumentLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateDocumentCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseDocument>, List<UpdateDocumentCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateDocumentCommand>, List<Entities.Document>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Document>, List<Entities.Document>>(MemberList.None);
        }
    }
}