using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.UpdateVendorContact
{
    public partial class UpdateVendorContactSetCommand : IRequest<List<VendorContactLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateVendorContactCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseVendorContact>, List<UpdateVendorContactCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateVendorContactCommand>, List<Entities.VendorContact>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.VendorContact>, List<Entities.VendorContact>>(MemberList.None);
        }
    }
}