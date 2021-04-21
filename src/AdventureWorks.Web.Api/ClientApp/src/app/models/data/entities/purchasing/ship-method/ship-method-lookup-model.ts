import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';

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
