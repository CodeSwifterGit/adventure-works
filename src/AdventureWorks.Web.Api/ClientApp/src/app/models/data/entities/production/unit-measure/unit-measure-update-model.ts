import { IBillOfMaterialsUpdateModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-update-model';
import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';
import { IProductVendorUpdateModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-update-model';

export interface IUnitMeasureUpdateModel {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class UnitMeasureUpdateModel implements IUnitMeasureUpdateModel {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<UnitMeasureUpdateModel>) {
    if (!!init) {
      Object.assign<UnitMeasureUpdateModel, Partial<UnitMeasureUpdateModel>>(this, init);
    }
  }
}
