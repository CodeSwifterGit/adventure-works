
export interface IPurchaseOrderDetailUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class PurchaseOrderDetailUpdateModel implements IPurchaseOrderDetailUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<PurchaseOrderDetailUpdateModel>) {
    if (!!init) {
      Object.assign<PurchaseOrderDetailUpdateModel, Partial<PurchaseOrderDetailUpdateModel>>(this, init);
    }
  }
}
