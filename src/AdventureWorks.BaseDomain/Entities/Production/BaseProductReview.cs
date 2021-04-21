using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductReview : IBaseEntity
    {
        public int ProductReviewID { get; set; }

        public int ProductID { get; set; }

        public string ReviewerName { get; set; }

        public DateTime ReviewDate { get; set; }

        public string EmailAddress { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}