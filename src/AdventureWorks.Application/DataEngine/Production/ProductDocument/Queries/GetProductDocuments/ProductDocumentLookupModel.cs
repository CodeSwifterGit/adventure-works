using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;


namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class ProductDocumentLookupModel : IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public int DocumentID { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Production.ProductDocument, ProductDocumentLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<ProductDocumentLookupModel, BaseProductDocument>().IgnoreMissingDestinationMembers();
        }
    }
}
