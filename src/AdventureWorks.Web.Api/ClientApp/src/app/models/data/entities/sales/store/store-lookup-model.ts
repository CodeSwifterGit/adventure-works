
export interface IStoreLookupModel {
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

export class StoreLookupModel implements IStoreLookupModel {
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

  constructor(init?: Partial<StoreLookupModel>) {
    if (!!init) {
      Object.assign<StoreLookupModel, Partial<StoreLookupModel>>(this, init);
    }
  }
}
