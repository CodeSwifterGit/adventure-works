
export interface ICultureUpdateModel {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CultureUpdateModel implements ICultureUpdateModel {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CultureUpdateModel>) {
    if (!!init) {
      Object.assign<CultureUpdateModel, Partial<CultureUpdateModel>>(this, init);
    }
  }
}
