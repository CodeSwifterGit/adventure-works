
export interface IContactTypeUpdateModel {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ContactTypeUpdateModel implements IContactTypeUpdateModel {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ContactTypeUpdateModel>) {
    if (!!init) {
      Object.assign<ContactTypeUpdateModel, Partial<ContactTypeUpdateModel>>(this, init);
    }
  }
}
