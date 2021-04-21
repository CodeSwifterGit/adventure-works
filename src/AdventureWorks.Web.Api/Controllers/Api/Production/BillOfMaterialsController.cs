using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Common.Security;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.CreateBillOfMaterials;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.DeleteBillOfMaterials;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.UpdateBillOfMaterials;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterialsDetail;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Web.Api.Controllers.Api.Production
{
    public partial class BillOfMaterialsController : BaseApiController
    {
        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{productAssemblyID}/{componentID}")]
        [ProducesResponseType(typeof(BillOfMaterialsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BillOfMaterialsListViewModel>> GetBillOfMaterialsByProduct(
            int? productAssemblyID, int componentID,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetBillOfMaterialsByProductListQuery()
            {
                ProductAssemblyID = productAssemblyID,
                ComponentID = componentID,
                DataTable = DataTableInfo<BillOfMaterialsSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("[action]/{unitMeasureCode}")]
        [ProducesResponseType(typeof(BillOfMaterialsListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BillOfMaterialsListViewModel>> GetBillOfMaterialsByUnitMeasure(
            string unitMeasureCode,
            [FromQuery] string[] sortByExpression,
            [FromQuery] string filterQuery,
            [FromQuery] string[] filterParameters,
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetBillOfMaterialsByUnitMeasureListQuery()
            {
                UnitMeasureCode = unitMeasureCode,
                DataTable = DataTableInfo<BillOfMaterialsSummary>.CreateInstance(sortByExpression, filterQuery, filterParameters, pageIndex, pageSize)
            }, cancellationToken));
        }


        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForReads)]
        [HttpGet("{billOfMaterialsID}")]
        [ProducesResponseType(typeof(BillOfMaterialsLookupModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BillOfMaterialsLookupModel>> Get(int billOfMaterialsID, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetBillOfMaterialsDetailQuery
            {
                BillOfMaterialsID = billOfMaterialsID
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost]
        [ProducesResponseType(typeof(BillOfMaterialsLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(BaseBillOfMaterials model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateBillOfMaterialsCommand(model, Mapper), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<BillOfMaterialsLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMany(List<BaseBillOfMaterials> model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateBillOfMaterialsSetCommand(model), cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("{billOfMaterialsID}")]
        [ProducesResponseType(typeof(BillOfMaterialsLookupModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int billOfMaterialsID, UpdateBillOfMaterialsCommand model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(model, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(List<BillOfMaterialsLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany(List<UpdateBillOfMaterialsCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new UpdateBillOfMaterialsSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpDelete("{billOfMaterialsID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int billOfMaterialsID, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteBillOfMaterialsCommand
            {
                BillOfMaterialsID = billOfMaterialsID
            }, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = SecurityPolicy.SampleSecurityPolicyForWrites)]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(List<BillOfMaterialsLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<DeleteBillOfMaterialsCommand> items, CancellationToken cancellationToken)
        {
            if (items == null) return NoContent();

            return Ok(await Mediator.Send(new DeleteBillOfMaterialsSetCommand()
            {
                Commands = items
            }, cancellationToken));
        }
    }
}