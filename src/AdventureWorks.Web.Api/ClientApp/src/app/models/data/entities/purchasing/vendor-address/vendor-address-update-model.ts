
export interface IVendorAddressUpdateModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorAddressUpdateModel implements IVendorAddressUpdateModel {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorAddressUpdateModel>) {
    if (!!init) {
      Object.assign<VendorAddressUpdateModel, Partial<VendorAddressUpdateModel>>(this, init);
    }
  }
}
