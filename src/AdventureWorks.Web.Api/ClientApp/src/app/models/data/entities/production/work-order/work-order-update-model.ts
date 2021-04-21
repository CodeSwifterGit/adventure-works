import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';
import { IScrapReasonUpdateModel } from 'app/models/data/entities/production/scrap-reason/scrap-reason-update-model';
import { IWorkOrderRoutingUpdateModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-update-model';

export interface IWorkOrderUpdateModel {
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

export class WorkOrderUpdateModel implements IWorkOrderUpdateModel {
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

  constructor(init?: Partial<WorkOrderUpdateModel>) {
    if (!!init) {
      Object.assign<WorkOrderUpdateModel, Partial<WorkOrderUpdateModel>>(this, init);
    }
  }
}
