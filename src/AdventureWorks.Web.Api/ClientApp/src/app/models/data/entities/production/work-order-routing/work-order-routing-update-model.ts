import { ILocationUpdateModel } from 'app/models/data/entities/production/location/location-update-model';
import { IWorkOrderUpdateModel } from 'app/models/data/entities/production/work-order/work-order-update-model';

export interface IWorkOrderRoutingUpdateModel {
  workOrderID: number;
  productID: number;
  operationSequence: number;
  locationID: number;
  scheduledStartDate: Date | string;
  scheduledEndDate: Date | string;
  actualStartDate: Date | string | null;
  actualEndDate: Date | string | null;
  actualResourceHrs: number | null;
  plannedCost: number;
  actualCost: number | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class WorkOrderRoutingUpdateModel implements IWorkOrderRoutingUpdateModel {
  workOrderID: number;
  productID: number;
  operationSequence: number;
  locationID: number;
  scheduledStartDate: Date | string;
  scheduledEndDate: Date | string;
  actualStartDate: Date | string | null;
  actualEndDate: Date | string | null;
  actualResourceHrs: number | null;
  plannedCost: number;
  actualCost: number | null;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<WorkOrderRoutingUpdateModel>) {
    if (!!init) {
      Object.assign<WorkOrderRoutingUpdateModel, Partial<WorkOrderRoutingUpdateModel>>(this, init);
    }
  }
}
