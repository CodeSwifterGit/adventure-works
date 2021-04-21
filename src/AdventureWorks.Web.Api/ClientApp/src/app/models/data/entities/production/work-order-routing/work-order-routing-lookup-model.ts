import { ILocationLookupModel } from 'app/models/data/entities/production/location/location-lookup-model';
import { IWorkOrderLookupModel } from 'app/models/data/entities/production/work-order/work-order-lookup-model';

export interface IWorkOrderRoutingLookupModel {
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

export class WorkOrderRoutingLookupModel implements IWorkOrderRoutingLookupModel {
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

  constructor(init?: Partial<WorkOrderRoutingLookupModel>) {
    if (!!init) {
      Object.assign<WorkOrderRoutingLookupModel, Partial<WorkOrderRoutingLookupModel>>(this, init);
    }
  }
}
