
export interface IAddressUpdateModel {
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

export class AddressUpdateModel implements IAddressUpdateModel {
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

  constructor(init?: Partial<AddressUpdateModel>) {
    if (!!init) {
      Object.assign<AddressUpdateModel, Partial<AddressUpdateModel>>(this, init);
    }
  }
}
