
export interface IVendorContactUpdateModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorContactUpdateModel implements IVendorContactUpdateModel {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorContactUpdateModel>) {
    if (!!init) {
      Object.assign<VendorContactUpdateModel, Partial<VendorContactUpdateModel>>(this, init);
    }
  }
}
