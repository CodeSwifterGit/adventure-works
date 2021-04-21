export interface IProductVendor {
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
}

export class ProductVendor implements IProductVendor {
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

  constructor(init?: Partial<ProductVendor>) {
    if (!!init) {
      Object.assign<ProductVendor, Partial<ProductVendor>>(this, init);
    }
  }
}
