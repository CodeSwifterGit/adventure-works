export interface IAddressType {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class AddressType implements IAddressType {
  addressTypeID: number;
  name: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<AddressType>) {
    if (!!init) {
      Object.assign<AddressType, Partial<AddressType>>(this, init);
    }
  }
}
