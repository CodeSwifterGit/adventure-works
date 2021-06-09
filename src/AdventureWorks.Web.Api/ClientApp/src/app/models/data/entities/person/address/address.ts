export interface IAddress {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class Address implements IAddress {
  addressID: number;
  addressLine1: string = '';
  addressLine2: string;
  city: string;
  stateProvinceID: number;
  postalCode: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Address>) {
    if (!!init) {
      Object.assign<Address, Partial<Address>>(this, init);
    }
  }
}
