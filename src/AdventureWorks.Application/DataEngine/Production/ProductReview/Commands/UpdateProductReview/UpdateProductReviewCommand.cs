using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.UpdateProductReview
{
    public partial class UpdateProductReviewCommand : BaseProductReview, IRequest<ProductReviewLookupModel>, IHaveCustomMapping
    {
        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductReviewRequestTarget RequestTarget { get; set; }

        public UpdateProductReviewCommand()
        {
        }

        public UpdateProductReviewCommand(int productReviewID, BaseProductReview model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductReviewRequestTarget(productReviewID);
        }

        public UpdateProductReviewCommand(int productReviewID)
        {
            ProductReviewID = productReviewID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductReview, UpdateProductReviewCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductReviewCommand, Entities.ProductReview>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductReview, Entities.ProductReview>(MemberList.None);
        }

        public partial class UpdateProductReviewRequestTarget
        {
            public int ProductReviewID { get; set; }

            public UpdateProductReviewRequestTarget()
            {
            }

            public UpdateProductReviewRequestTarget(int productReviewID)
            {
                ProductReviewID = productReviewID;
            }
        }
    }
}