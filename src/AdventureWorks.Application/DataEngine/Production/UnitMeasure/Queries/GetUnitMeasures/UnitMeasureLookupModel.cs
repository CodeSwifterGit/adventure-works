using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures
{
    public partial class UnitMeasureLookupModel : IHaveCustomMapping
    {
        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Production.UnitMeasure, UnitMeasureLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<UnitMeasureLookupModel, BaseUnitMeasure>().IgnoreMissingDestinationMembers();
        }
    }
}
