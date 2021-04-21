export interface IWorkOrder {
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
}

export class WorkOrder implements IWorkOrder {
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

  constructor(init?: Partial<WorkOrder>) {
    if (!!init) {
      Object.assign<WorkOrder, Partial<WorkOrder>>(this, init);
    }
  }
}
