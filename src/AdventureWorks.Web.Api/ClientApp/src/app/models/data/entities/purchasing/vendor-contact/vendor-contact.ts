export interface IVendorContact {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;
}

export class VendorContact implements IVendorContact {
  vendorID: number;
  contactID: number;
  contactTypeID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<VendorContact>) {
    if (!!init) {
      Object.assign<VendorContact, Partial<VendorContact>>(this, init);
    }
  }
}
