
export interface IStoreContactUpdateModel {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class StoreContactUpdateModel implements IStoreContactUpdateModel {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StoreContactUpdateModel>) {
    if (!!init) {
      Object.assign<StoreContactUpdateModel, Partial<StoreContactUpdateModel>>(this, init);
    }
  }
}
