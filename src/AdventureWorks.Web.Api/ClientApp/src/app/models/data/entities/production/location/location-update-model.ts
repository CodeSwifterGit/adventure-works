import { IProductInventoryUpdateModel } from 'app/models/data/entities/production/product-inventory/product-inventory-update-model';
import { IWorkOrderRoutingUpdateModel } from 'app/models/data/entities/production/work-order-routing/work-order-routing-update-model';

export interface ILocationUpdateModel {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class LocationUpdateModel implements ILocationUpdateModel {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<LocationUpdateModel>) {
    if (!!init) {
      Object.assign<LocationUpdateModel, Partial<LocationUpdateModel>>(this, init);
    }
  }
}
