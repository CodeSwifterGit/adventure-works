export interface IPurchaseOrderDetail {
  purchaseOrderID: number;
  purchaseOrderDetailID: number;
  dueDate: Date | string;
  orderQty: number;
  productID: number;
  unitPrice: number;
  lineTotal: number;
  receivedQty: number;
  rejectedQty: number;
  stockedQty: number;
  modifiedDate: Date | string;
}

export class PurchaseOrderDetail implements IPurchaseOrderDetail {
  purchaseOrderID: number;
  purchaseOrderDetailID: number;
  dueDate: Date | string;
  orderQty: number;
  productID: number;
  unitPrice: number;
  lineTotal: number;
  receivedQty: number;
  rejectedQty: number;
  stockedQty: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<PurchaseOrderDetail>) {
    if (!!init) {
      Object.assign<PurchaseOrderDetail, Partial<PurchaseOrderDetail>>(this, init);
    }
  }
}
