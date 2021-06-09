
export interface IProductVendorUpdateModel {
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

export class ProductVendorUpdateModel implements IProductVendorUpdateModel {
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

  constructor(init?: Partial<ProductVendorUpdateModel>) {
    if (!!init) {
      Object.assign<ProductVendorUpdateModel, Partial<ProductVendorUpdateModel>>(this, init);
    }
  }
}
