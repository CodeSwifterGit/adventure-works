import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';

export interface IPurchaseOrderDetailLookupModel {
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

export class PurchaseOrderDetailLookupModel implements IPurchaseOrderDetailLookupModel {
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

  constructor(init?: Partial<PurchaseOrderDetailLookupModel>) {
    if (!!init) {
      Object.assign<PurchaseOrderDetailLookupModel, Partial<PurchaseOrderDetailLookupModel>>(this, init);
    }
  }
}
