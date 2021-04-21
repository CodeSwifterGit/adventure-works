import { ISalesOrderHeaderSalesReasonLookupModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-lookup-model';

export interface ISalesReasonLookupModel {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesReasonLookupModel implements ISalesReasonLookupModel {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesReasonLookupModel>) {
    if (!!init) {
      Object.assign<SalesReasonLookupModel, Partial<SalesReasonLookupModel>>(this, init);
    }
  }
}
