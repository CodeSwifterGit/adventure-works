import { IBillOfMaterialsLookupModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-lookup-model';
import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';

export interface IUnitMeasureLookupModel {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class UnitMeasureLookupModel implements IUnitMeasureLookupModel {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<UnitMeasureLookupModel>) {
    if (!!init) {
      Object.assign<UnitMeasureLookupModel, Partial<UnitMeasureLookupModel>>(this, init);
    }
  }
}
