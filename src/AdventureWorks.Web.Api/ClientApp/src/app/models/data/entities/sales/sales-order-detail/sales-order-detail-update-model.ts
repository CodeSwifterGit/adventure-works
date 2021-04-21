import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { ISpecialOfferProductUpdateModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-update-model';

export interface ISalesOrderDetailUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesOrderDetailUpdateModel implements ISalesOrderDetailUpdateModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesOrderDetailUpdateModel>) {
    if (!!init) {
      Object.assign<SalesOrderDetailUpdateModel, Partial<SalesOrderDetailUpdateModel>>(this, init);
    }
  }
}
