using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.UpdateSalesTaxRate
{
    public partial class UpdateSalesTaxRateCommand : BaseSalesTaxRate, IRequest<SalesTaxRateLookupModel>, IHaveCustomMapping
    {
        public int SalesTaxRateID { get; set; }
        public int StateProvinceID { get; set; }
        public byte TaxType { get; set; }
        public decimal TaxRate { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesTaxRateRequestTarget RequestTarget { get; set; }

        public UpdateSalesTaxRateCommand()
        {
        }

        public UpdateSalesTaxRateCommand(int salesTaxRateID, BaseSalesTaxRate model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesTaxRateRequestTarget(salesTaxRateID);
        }

        public UpdateSalesTaxRateCommand(int salesTaxRateID)
        {
            SalesTaxRateID = salesTaxRateID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTaxRate, UpdateSalesTaxRateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesTaxRateCommand, Entities.SalesTaxRate>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesTaxRate, Entities.SalesTaxRate>(MemberList.None);
        }

        public partial class UpdateSalesTaxRateRequestTarget
        {
            public int SalesTaxRateID { get; set; }

            public UpdateSalesTaxRateRequestTarget()
            {
            }

            public UpdateSalesTaxRateRequestTarget(int salesTaxRateID)
            {
                SalesTaxRateID = salesTaxRateID;
            }
        }
    }
}