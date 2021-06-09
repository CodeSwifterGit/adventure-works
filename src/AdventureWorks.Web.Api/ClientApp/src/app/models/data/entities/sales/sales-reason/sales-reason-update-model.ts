
export interface ISalesReasonUpdateModel {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesReasonUpdateModel implements ISalesReasonUpdateModel {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesReasonUpdateModel>) {
    if (!!init) {
      Object.assign<SalesReasonUpdateModel, Partial<SalesReasonUpdateModel>>(this, init);
    }
  }
}
