export interface IPurchaseOrderHeader {
  purchaseOrderID: number;
  revisionNumber: number;
  status: number;
  employeeID: number;
  vendorID: number;
  shipMethodID: number;
  orderDate: Date | string;
  shipDate: Date | string | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  modifiedDate: Date | string;
}

export class PurchaseOrderHeader implements IPurchaseOrderHeader {
  purchaseOrderID: number;
  revisionNumber: number;
  status: number;
  employeeID: number;
  vendorID: number;
  shipMethodID: number;
  orderDate: Date | string;
  shipDate: Date | string | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<PurchaseOrderHeader>) {
    if (!!init) {
      Object.assign<PurchaseOrderHeader, Partial<PurchaseOrderHeader>>(this, init);
    }
  }
}
