
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
