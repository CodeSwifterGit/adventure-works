
export interface IAddressLookupModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AddressLookupModel implements IAddressLookupModel {
  addressID: number;
  addressLine1: string = '';
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AddressLookupModel>) {
    if (!!init) {
      Object.assign<AddressLookupModel, Partial<AddressLookupModel>>(this, init);
    }
  }
}
