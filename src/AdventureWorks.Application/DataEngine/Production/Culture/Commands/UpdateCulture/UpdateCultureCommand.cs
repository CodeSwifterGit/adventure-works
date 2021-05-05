using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.UpdateCulture
{
    public partial class UpdateCultureCommand : IRequest<CultureLookupModel>, IHaveCustomMapping
    {
        public string CultureID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCultureRequestTarget RequestTarget { get; set; }

        public UpdateCultureCommand()
        {
        }

        public UpdateCultureCommand(string cultureID, BaseCulture model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCultureRequestTarget(cultureID);
        }

        public UpdateCultureCommand(string cultureID)
        {
            CultureID = cultureID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCulture, UpdateCultureCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCultureCommand, Entities.Culture>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Culture, Entities.Culture>(MemberList.None);
        }

        public partial class UpdateCultureRequestTarget
        {
            public string CultureID { get; set; }

            public UpdateCultureRequestTarget()
            {
            }

            public UpdateCultureRequestTarget(string cultureID)
            {
                CultureID = cultureID;
            }
        }
    }
}