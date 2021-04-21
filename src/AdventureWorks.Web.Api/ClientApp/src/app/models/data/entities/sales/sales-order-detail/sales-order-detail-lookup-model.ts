import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISpecialOfferProductLookupModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-lookup-model';

export interface ISalesOrderDetailLookupModel {
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

export class SalesOrderDetailLookupModel implements ISalesOrderDetailLookupModel {
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

  constructor(init?: Partial<SalesOrderDetailLookupModel>) {
    if (!!init) {
      Object.assign<SalesOrderDetailLookupModel, Partial<SalesOrderDetailLookupModel>>(this, init);
    }
  }
}
