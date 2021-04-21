export interface ISalesOrderDetail {
  salesOrderID: number;
  salesOrderDetailID: number;
  carrierTrackingNumber: string;
  orderQty: number;
  productID: number;
  specialOfferID: number;
  unitPrice: number;
  unitPriceDiscount: number;
  lineTotal: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesOrderDetail implements ISalesOrderDetail {
  salesOrderID: number;
  salesOrderDetailID: number;
  carrierTrackingNumber: string;
  orderQty: number;
  productID: number;
  specialOfferID: number;
  unitPrice: number;
  unitPriceDiscount: number;
  lineTotal: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesOrderDetail>) {
    if (!!init) {
      Object.assign<SalesOrderDetail, Partial<SalesOrderDetail>>(this, init);
    }
  }
}
