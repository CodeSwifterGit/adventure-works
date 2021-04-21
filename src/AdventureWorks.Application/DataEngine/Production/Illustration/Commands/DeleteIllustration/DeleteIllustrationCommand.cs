using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration
{
    public partial class DeleteIllustrationCommand : IRequest
    {
        public int IllustrationID { get; set; }
    }
}