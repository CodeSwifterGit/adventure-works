using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductPhoto : IBaseEntity
    {
        public int ProductPhotoID { get; set; }

        public byte[] ThumbNailPhoto { get; set; }

        public string ThumbnailPhotoFileName { get; set; }

        public byte[] LargePhoto { get; set; }

        public string LargePhotoFileName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}