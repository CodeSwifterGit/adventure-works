
export interface ISalesOrderHeaderSalesReasonUpdateModel {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesOrderHeaderSalesReasonUpdateModel implements ISalesOrderHeaderSalesReasonUpdateModel {
  salesOrderID: number;
  salesReasonID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesOrderHeaderSalesReasonUpdateModel>) {
    if (!!init) {
      Object.assign<SalesOrderHeaderSalesReasonUpdateModel, Partial<SalesOrderHeaderSalesReasonUpdateModel>>(this, init);
    }
  }
}
