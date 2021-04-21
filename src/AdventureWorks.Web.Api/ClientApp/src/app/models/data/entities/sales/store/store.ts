export interface IStore {
  customerID: number;
  name: string;
  salesPersonID: number | null;
  demographics: string;
  rowguid: string;
  modifiedDate: Date | string;
}

export class Store implements IStore {
  customerID: number;
  name: string;
  salesPersonID: number | null;
  demographics: string;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Store>) {
    if (!!init) {
      Object.assign<Store, Partial<Store>>(this, init);
    }
  }
}
