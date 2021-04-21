export interface ISalesOrderHeaderSalesReason {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;
}

export class SalesOrderHeaderSalesReason implements ISalesOrderHeaderSalesReason {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesOrderHeaderSalesReason>) {
    if (!!init) {
      Object.assign<SalesOrderHeaderSalesReason, Partial<SalesOrderHeaderSalesReason>>(this, init);
    }
  }
}
