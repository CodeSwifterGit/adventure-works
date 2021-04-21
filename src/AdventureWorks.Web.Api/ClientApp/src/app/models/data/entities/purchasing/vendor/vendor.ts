export interface IVendor {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;
}

export class Vendor implements IVendor {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Vendor>) {
    if (!!init) {
      Object.assign<Vendor, Partial<Vendor>>(this, init);
    }
  }
}
