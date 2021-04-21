export interface IShipMethod {
  shipMethodID: number;
  name: string;
  shipBase: number;
  shipRate: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class ShipMethod implements IShipMethod {
  shipMethodID: number;
  name: string;
  shipBase: number;
  shipRate: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ShipMethod>) {
    if (!!init) {
      Object.assign<ShipMethod, Partial<ShipMethod>>(this, init);
    }
  }
}
