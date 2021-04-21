using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.UpdateSpecialOfferProduct
{
    public partial class UpdateSpecialOfferProductCommand : BaseSpecialOfferProduct, IRequest<SpecialOfferProductLookupModel>, IHaveCustomMapping
    {
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSpecialOfferProductRequestTarget RequestTarget { get; set; }

        public UpdateSpecialOfferProductCommand()
        {
        }

        public UpdateSpecialOfferProductCommand(int specialOfferID, int productID, BaseSpecialOfferProduct model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSpecialOfferProductRequestTarget(specialOfferID, productID);
        }

        public UpdateSpecialOfferProductCommand(int specialOfferID, int productID)
        {
            SpecialOfferID = specialOfferID;
            ProductID = productID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSpecialOfferProduct, UpdateSpecialOfferProductCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSpecialOfferProductCommand, Entities.SpecialOfferProduct>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SpecialOfferProduct, Entities.SpecialOfferProduct>(MemberList.None);
        }

        public partial class UpdateSpecialOfferProductRequestTarget
        {
            public int SpecialOfferID { get; set; }
            public int ProductID { get; set; }

            public UpdateSpecialOfferProductRequestTarget()
            {
            }

            public UpdateSpecialOfferProductRequestTarget(int specialOfferID, int productID)
            {
                SpecialOfferID = specialOfferID;
                ProductID = productID;
            }
        }
    }
}