using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.DeleteAWBuildVersion
{
    public partial class DeleteAWBuildVersionCommand : IRequest
    {
        public byte SystemInformationID { get; set; }
    }
}