export interface IStoreContact {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class StoreContact implements IStoreContact {
  customerID: number;
  contactID: number;
  contactTypeID: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<StoreContact>) {
    if (!!init) {
      Object.assign<StoreContact, Partial<StoreContact>>(this, init);
    }
  }
}
