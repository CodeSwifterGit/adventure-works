
export interface IShipMethodLookupModel {
  shipMethodID: number;
  name: string;
  shipBase: number;
  shipRate: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ShipMethodLookupModel implements IShipMethodLookupModel {
  shipMethodID: number;
  name: string;
  shipBase: number;
  shipRate: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ShipMethodLookupModel>) {
    if (!!init) {
      Object.assign<ShipMethodLookupModel, Partial<ShipMethodLookupModel>>(this, init);
    }
  }
}
