
export interface IContactTypeLookupModel {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ContactTypeLookupModel implements IContactTypeLookupModel {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ContactTypeLookupModel>) {
    if (!!init) {
      Object.assign<ContactTypeLookupModel, Partial<ContactTypeLookupModel>>(this, init);
    }
  }
}
