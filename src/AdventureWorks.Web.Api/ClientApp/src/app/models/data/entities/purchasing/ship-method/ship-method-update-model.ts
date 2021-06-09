
export interface IShipMethodUpdateModel {
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

export class ShipMethodUpdateModel implements IShipMethodUpdateModel {
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

  constructor(init?: Partial<ShipMethodUpdateModel>) {
    if (!!init) {
      Object.assign<ShipMethodUpdateModel, Partial<ShipMethodUpdateModel>>(this, init);
    }
  }
}
