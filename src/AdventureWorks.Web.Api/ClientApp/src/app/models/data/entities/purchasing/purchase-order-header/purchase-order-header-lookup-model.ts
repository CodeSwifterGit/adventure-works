
export interface IPurchaseOrderHeaderLookupModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class PurchaseOrderHeaderLookupModel implements IPurchaseOrderHeaderLookupModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<PurchaseOrderHeaderLookupModel>) {
    if (!!init) {
      Object.assign<PurchaseOrderHeaderLookupModel, Partial<PurchaseOrderHeaderLookupModel>>(this, init);
    }
  }
}
