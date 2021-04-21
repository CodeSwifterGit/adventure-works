export interface IWorkOrderRouting {
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
}

export class WorkOrderRouting implements IWorkOrderRouting {
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

  constructor(init?: Partial<WorkOrderRouting>) {
    if (!!init) {
      Object.assign<WorkOrderRouting, Partial<WorkOrderRouting>>(this, init);
    }
  }
}
