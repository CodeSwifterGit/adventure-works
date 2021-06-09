
export interface IVendorContactLookupModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorContactLookupModel implements IVendorContactLookupModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorContactLookupModel>) {
    if (!!init) {
      Object.assign<VendorContactLookupModel, Partial<VendorContactLookupModel>>(this, init);
    }
  }
}
