using System.Collections.Generic;
using NJsonSchema.Validation;

namespace AdventureWorks.Common.Models
{
    public class SchemaValidationResult
    {
        public IList<ValidationError> Errors { get; set; }
    }
}