using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.UpdateProductReview
{
    public partial class UpdateProductReviewSetCommand : IRequest<List<ProductReviewLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductReviewCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductReview>, List<UpdateProductReviewCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductReviewCommand>, List<Entities.ProductReview>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductReview>, List<Entities.ProductReview>>(MemberList.None);
        }
    }
}