
export interface IStoreUpdateModel {
  customerID: number;
  name: string;
  salesPersonID: number | null;
  demographics: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class StoreUpdateModel implements IStoreUpdateModel {
  customerID: number;
  name: string;
  salesPersonID: number | null;
  demographics: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StoreUpdateModel>) {
    if (!!init) {
      Object.assign<StoreUpdateModel, Partial<StoreUpdateModel>>(this, init);
    }
  }
}
