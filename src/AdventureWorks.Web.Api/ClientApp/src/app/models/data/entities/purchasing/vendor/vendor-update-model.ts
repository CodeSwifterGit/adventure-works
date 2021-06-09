
export interface IVendorUpdateModel {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorUpdateModel implements IVendorUpdateModel {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorUpdateModel>) {
    if (!!init) {
      Object.assign<VendorUpdateModel, Partial<VendorUpdateModel>>(this, init);
    }
  }
}
