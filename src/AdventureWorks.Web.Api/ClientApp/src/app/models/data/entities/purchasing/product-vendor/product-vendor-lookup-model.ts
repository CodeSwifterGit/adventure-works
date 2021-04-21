import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';
import { IUnitMeasureLookupModel } from 'app/models/data/entities/production/unit-measure/unit-measure-lookup-model';
import { IVendorLookupModel } from 'app/models/data/entities/purchasing/vendor/vendor-lookup-model';

export interface IProductVendorLookupModel {
  productID: number;
  vendorID: number;
  averageLeadTime: number;
  standardPrice: number;
  lastReceiptCost: number | null;
  lastReceiptDate: Date | string | null;
  minOrderQty: number;
  maxOrderQty: number;
  onOrderQty: number | null;
  unitMeasureCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductVendorLookupModel implements IProductVendorLookupModel {
  productID: number;
  vendorID: number;
  averageLeadTime: number;
  standardPrice: number;
  lastReceiptCost: number | null;
  lastReceiptDate: Date | string | null;
  minOrderQty: number;
  maxOrderQty: number;
  onOrderQty: number | null;
  unitMeasureCode: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductVendorLookupModel>) {
    if (!!init) {
      Object.assign<ProductVendorLookupModel, Partial<ProductVendorLookupModel>>(this, init);
    }
  }
}
