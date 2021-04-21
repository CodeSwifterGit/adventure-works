using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class VendorContactLookupModel : IHaveCustomMapping
    {
        public int VendorID { get; set; }
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Purchasing.VendorContact, VendorContactLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<VendorContactLookupModel, BaseVendorContact>().IgnoreMissingDestinationMembers();
        }
    }
}
