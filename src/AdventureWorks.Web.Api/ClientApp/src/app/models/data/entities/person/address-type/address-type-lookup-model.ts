
export interface IAddressTypeLookupModel {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AddressTypeLookupModel implements IAddressTypeLookupModel {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AddressTypeLookupModel>) {
    if (!!init) {
      Object.assign<AddressTypeLookupModel, Partial<AddressTypeLookupModel>>(this, init);
    }
  }
}
