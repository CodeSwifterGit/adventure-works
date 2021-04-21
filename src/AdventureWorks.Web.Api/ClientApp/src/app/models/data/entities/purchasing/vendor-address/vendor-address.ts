export interface IVendorAddress {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;
}

export class VendorAddress implements IVendorAddress {
  vendorID: number;
  addressID: number;
  addressTypeID: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<VendorAddress>) {
    if (!!init) {
      Object.assign<VendorAddress, Partial<VendorAddress>>(this, init);
    }
  }
}
