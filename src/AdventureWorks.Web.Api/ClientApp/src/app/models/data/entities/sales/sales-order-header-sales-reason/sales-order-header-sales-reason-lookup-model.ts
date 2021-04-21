import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesReasonLookupModel } from 'app/models/data/entities/sales/sales-reason/sales-reason-lookup-model';

export interface ISalesOrderHeaderSalesReasonLookupModel {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesOrderHeaderSalesReasonLookupModel implements ISalesOrderHeaderSalesReasonLookupModel {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesOrderHeaderSalesReasonLookupModel>) {
    if (!!init) {
      Object.assign<SalesOrderHeaderSalesReasonLookupModel, Partial<SalesOrderHeaderSalesReasonLookupModel>>(this, init);
    }
  }
}
