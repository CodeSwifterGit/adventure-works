
export interface ICultureLookupModel {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CultureLookupModel implements ICultureLookupModel {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CultureLookupModel>) {
    if (!!init) {
      Object.assign<CultureLookupModel, Partial<CultureLookupModel>>(this, init);
    }
  }
}
