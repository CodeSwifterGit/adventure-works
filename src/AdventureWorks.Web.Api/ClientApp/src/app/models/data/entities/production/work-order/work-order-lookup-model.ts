import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IScrapReasonLookupModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-lookup-model';
import { IWorkOrderRoutingLookupModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-lookup-model';

export interface IWorkOrderLookupModel {
  workOrderID: number;
  productID: number;
  orderQty: number;
  stockedQty: number;
  scrappedQty: number;
  startDate: Date | string;
  endDate: Date | string | null;
  dueDate: Date | string;
  scrapReasonID: number | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class WorkOrderLookupModel implements IWorkOrderLookupModel {
  workOrderID: number;
  productID: number;
  orderQty: number;
  stockedQty: number;
  scrappedQty: number;
  startDate: Date | string;
  endDate: Date | string | null;
  dueDate: Date | string;
  scrapReasonID: number | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<WorkOrderLookupModel>) {
    if (!!init) {
      Object.assign<WorkOrderLookupModel, Partial<WorkOrderLookupModel>>(this, init);
    }
  }
}
