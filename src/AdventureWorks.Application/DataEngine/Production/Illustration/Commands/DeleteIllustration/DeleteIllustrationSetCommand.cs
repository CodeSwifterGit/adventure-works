using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration
{
    public partial class DeleteIllustrationSetCommand : IRequest
    {
        public List<DeleteIllustrationCommand> Commands { get; set; }
    }
}